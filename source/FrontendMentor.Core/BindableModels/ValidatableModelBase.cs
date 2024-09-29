// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FrontendMentor.Core.BindableModels;

/// <summary>
///     An abstract base class that supports validation and implements the INotifyDataErrorInfo interface for error
///     tracking and notifications
/// </summary>
public abstract class ValidatableModelBase : BindableModelBase, INotifyDataErrorInfo
{
    /// <summary>
    ///     Dictionary to hold errors for each property. The key is the property name, and the value is a list of error
    ///     messages.
    /// </summary>
    private readonly Dictionary<string, List<string>> _errors = new();

    /// <summary>
    ///     Occurs when the validation errors for a property have changed.
    /// </summary>
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    /// <summary>
    ///     Indicates whether the object currently has any validation errors.
    /// </summary>
    public bool HasErrors => _errors.Count > 0;

    /// <summary>
    ///     Retrieves validation errors for the specified property.
    ///     If the property name is null or empty, an empty collection is returned.
    /// </summary>
    /// <param name="propertyName">The name of the property to retrieve errors for. If null or empty, no errors are returned.</param>
    /// <returns>
    ///     An IEnumerable containing the validation error messages for the specified property, or an empty collection if
    ///     none exist.
    /// </returns>
    public IEnumerable GetErrors(string? propertyName)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            return Enumerable.Empty<string>();
        }

        return _errors.TryGetValue(propertyName, out var errors) ? errors : Enumerable.Empty<string>();
    }

    /// <summary>
    ///     Clears all validation errors from the object.
    /// </summary>
    public void ClearErrors()
    {
        foreach (var error in _errors.ToList())
        {
            RemoveError(error.Key);
        }
    }

    /// <summary>
    ///     Notifies subscribers when the validation errors for a property have changed and raises property change
    ///     notifications for HasErrors
    /// </summary>
    /// <param name="propertyName">The name of the property whose validation errors have changed.</param>
    protected virtual void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        RaisePropertyChanged(nameof(HasErrors));
    }

    /// <summary>
    ///     Sets the property and performs validation. If the value is changed, it triggers validation for the given property.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="storage">Reference to the backing field storing the property value.</param>
    /// <param name="value">The new value to set.</param>
    /// <param name="propertyName">The name of the property</param>
    protected virtual void SetValidatedProperty<TValue>(ref TValue storage, TValue value,
        [CallerMemberName] string? propertyName = null)
    {
        if (!SetProperty(ref storage, value, propertyName))
        {
            return;
        }

        ValidateProperty(value, this, propertyName);
    }

    /// <summary>
    ///     Sets the property, performs validation, and executes an optional callback if the value changes.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="storage">Reference to the backing field storing the property value.</param>
    /// <param name="value">The new value to set.</param>
    /// <param name="onChanged">An action to invoke when the value has changed.</param>
    /// <param name="propertyName">The name of the property</param>
    protected virtual void SetValidatedProperty<TValue>(ref TValue storage, TValue value, Action? onChanged,
        [CallerMemberName] string? propertyName = null)
    {
        if (!SetProperty(ref storage, value, propertyName))
        {
            return;
        }

        ValidateProperty(value, this, propertyName);

        onChanged?.Invoke();
    }

    private void RemoveError([CallerMemberName] string? propertyName = null)
    {
        if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
        {
            return;
        }

        _errors.Remove(propertyName);

        OnErrorsChanged(propertyName);
    }

    private void AddError(string propertyName, string errorMessage, bool isWarning = false)
    {
        if (!_errors.TryGetValue(propertyName, out var propertyErrors))
        {
            propertyErrors = [];

            _errors[propertyName] = propertyErrors;
        }

        if (propertyErrors.Contains(errorMessage))
        {
            return;
        }

        if (isWarning)
        {
            propertyErrors.Add(errorMessage);
        }
        else
        {
            propertyErrors.Insert(0, errorMessage);
        }

        OnErrorsChanged(propertyName);
    }

    /// <summary>
    ///     Validates the specified property against data annotations and adds any validation errors.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="instance">The instance containing the property.</param>
    /// <param name="propertyName">The name of the property to validate</param>
    /// <returns>True if the property is valid; otherwise, false.</returns>
    public bool ValidateProperty(object? value, object instance, [CallerMemberName] string? propertyName = null)
    {
        RemoveError(propertyName);

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(instance) { MemberName = propertyName };

        var isValid = Validator.TryValidateProperty(value, validationContext, validationResults);

        if (!isValid)
        {
            AddValidationErrors(validationResults);
        }

        return isValid;
    }

    /// <summary>
    ///     Validates the specified object against data annotations and collects validation errors.
    ///     If validation fails, errors are added to the errors collection.
    /// </summary>
    /// <param name="instance">The object to validate.</param>
    /// <param name="clearErrors">Specifies whether to clear existing errors before validating. Default is true.</param>
    /// <returns>True if the object is valid; otherwise, false.</returns>
    protected bool ValidateObject(object instance, bool clearErrors = true)
    {
        if (clearErrors)
        {
            ClearErrors();
        }

        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(instance, new ValidationContext(instance), validationResults, true);

        if (!isValid)
        {
            AddValidationErrors(validationResults);
        }

        return isValid;
    }

    /// <summary>
    ///     Validates the entire object or clears errors depending on the isEnabled flag.
    /// </summary>
    /// <param name="isEnabled">Indicates whether validation should be performed or just errors should be cleared.</param>
    /// <param name="clearErrors">Indicates whether to clear existing errors before validating.</param>
    /// <returns>True if the object is valid; otherwise, false.</returns>
    public virtual bool Validate(bool isEnabled = true, bool clearErrors = true)
    {
        if (isEnabled)
        {
            return ValidateObject(this, clearErrors);
        }

        if (clearErrors)
        {
            ClearErrors();
        }

        return true;
    }

    private void AddValidationErrors(IEnumerable<ValidationResult> validationResults)
    {
        foreach (var result in validationResults)
        {
            foreach (var memberName in result.MemberNames)
            {
                if (result.ErrorMessage != null)
                {
                    AddError(memberName, result.ErrorMessage);
                }
            }
        }
    }
}