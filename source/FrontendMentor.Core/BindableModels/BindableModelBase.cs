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

using FrontendMentor.Core.Attributes;
using FrontendMentor.Core.Interfaces;
using System.ComponentModel;

namespace FrontendMentor.Core.BindableModels;

/// <summary>
///     Provides a base class that extends <see cref="BindableBase" /> and implements <see cref="IResettable" /> and
///     <see cref="IChangeTracking" /> interfaces.
///     This class supports property change notification, change tracking using the <see cref="TrackableAttribute" />,
///     and resetting properties to default values through the use of the <see cref="ResettableAttribute" />.
/// </summary>
public abstract class BindableModelBase : BindableBase, IResettable, IChangeTracking
{
    private bool _isChanged;

    /// <summary>
    ///     Marks all changes as accepted, resetting the <see cref="IsChanged" /> flag to false.
    /// </summary>
    public void AcceptChanges()
    {
        IsChanged = false;
    }

    /// <summary>
    ///     Gets or sets a value indicating whether any tracked properties have changed.
    /// </summary>
    public bool IsChanged
    {
        get => _isChanged;
        protected set => SetProperty(ref _isChanged, value);
    }

    /// <summary>
    ///     Resets all properties marked with the <see cref="ResettableAttribute" /> to their default values.
    ///     If a <see cref="ResettableAttribute.DefaultValue" /> is provided, the property is reset to that value.
    ///     Otherwise, the property is reset to the default for its type.
    /// </summary>
    public virtual void Reset()
    {
        var properties = GetType().GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(ResettableAttribute)));

        foreach (var property in properties)
        {
            var attribute =
                (ResettableAttribute)property.GetCustomAttributes(typeof(ResettableAttribute), false).First();

            if (attribute.DefaultValue != null)
            {
                property.SetValue(this, attribute.DefaultValue);
            }
            else
            {
                var defaultValue = property.PropertyType.IsValueType
                    ? Activator.CreateInstance(property.PropertyType)
                    : null;

                property.SetValue(this, defaultValue);
            }
        }
    }

    /// <summary>
    ///     Overrides the property change logic to set the <see cref="IsChanged" /> flag to true when a property
    ///     marked with the <see cref="TrackableAttribute" /> changes.
    /// </summary>
    /// <param name="args">Information about the property change event.</param>
    protected override void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        base.OnPropertyChanged(args);

        if (string.IsNullOrEmpty(args.PropertyName))
        {
            return;
        }

        var property = GetType().GetProperty(args.PropertyName);

        if (property == null)
        {
            return;
        }

        if (property.GetCustomAttributes(typeof(TrackableAttribute), true).Length > 0)
        {
            IsChanged = true;
        }
    }
}