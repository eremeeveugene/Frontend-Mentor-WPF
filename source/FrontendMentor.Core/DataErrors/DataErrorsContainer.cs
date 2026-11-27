// --------------------------------------------------------------------------------
// Copyright (C) 2026 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
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

namespace FrontendMentor.Core.DataErrors;

/// <summary>
///     Stores the validation errors of the properties of an object and reports them through
///     <see cref="INotifyDataErrorInfo" />. A view model forwards its <see cref="INotifyDataErrorInfo" /> members to
///     it, so bindings show the errors through <c>Validation.HasError</c> and <c>Validation.Errors</c>.
/// </summary>
/// <remarks>
///     Each property has at most one error, which is the first problem that validation found.
/// </remarks>
public sealed class DataErrorsContainer : INotifyDataErrorInfo
{
    private static readonly string[] NoErrors = [];

    private readonly Dictionary<string, string> _errors = new(StringComparer.Ordinal);
    private readonly object _owner;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DataErrorsContainer" /> class.
    /// </summary>
    /// <param name="owner">The object whose errors are stored. It is the sender of <see cref="ErrorsChanged" />.</param>
    public DataErrorsContainer(object owner)
    {
        _owner = owner;
    }

    /// <inheritdoc />
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    /// <inheritdoc />
    public bool HasErrors => _errors.Count > 0;

    /// <inheritdoc />
    public IEnumerable GetErrors(string? propertyName)
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            return new List<string>(_errors.Values);
        }

        return _errors.TryGetValue(propertyName, out var error) ? new[] { error } : NoErrors;
    }

    /// <summary>
    ///     Sets or clears the error of a property.
    /// </summary>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="error">The error, or <c>null</c> to clear it.</param>
    public void SetError(string propertyName, string? error)
    {
        if (error == null)
        {
            ClearError(propertyName);

            return;
        }

        if (_errors.TryGetValue(propertyName, out var currentError) && currentError == error)
        {
            return;
        }

        _errors[propertyName] = error;

        RaiseErrorsChanged(propertyName);
    }

    /// <summary>
    ///     Clears the error of a property, if it has one.
    /// </summary>
    /// <param name="propertyName">The name of the property.</param>
    public void ClearError(string propertyName)
    {
        if (_errors.Remove(propertyName))
        {
            RaiseErrorsChanged(propertyName);
        }
    }

    /// <summary>
    ///     Clears the errors of all properties.
    /// </summary>
    public void ClearErrors()
    {
        var propertyNames = new List<string>(_errors.Keys);

        _errors.Clear();

        foreach (var propertyName in propertyNames)
        {
            RaiseErrorsChanged(propertyName);
        }
    }

    private void RaiseErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(_owner, new DataErrorsChangedEventArgs(propertyName));
    }
}