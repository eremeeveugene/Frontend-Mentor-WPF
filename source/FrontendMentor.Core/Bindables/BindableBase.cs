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

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FrontendMentor.Core.Bindables;

/// <summary>
///     The base class for objects that notify about property changes.
/// </summary>
public abstract class BindableBase : INotifyPropertyChanged
{
    /// <inheritdoc />
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    ///     Sets a property backing field and raises <see cref="PropertyChanged" /> when the value changed.
    /// </summary>
    /// <typeparam name="T">The property type.</typeparam>
    /// <param name="storage">The property backing field.</param>
    /// <param name="value">The new value.</param>
    /// <param name="propertyName">The property name. Filled in by the compiler.</param>
    /// <returns><c>true</c> when the value changed; otherwise, <c>false</c>.</returns>
    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value))
        {
            return false;
        }

        storage = value;

        RaisePropertyChanged(propertyName);

        return true;
    }

    /// <summary>
    ///     Raises <see cref="PropertyChanged" />.
    /// </summary>
    /// <param name="propertyName">The property name. Filled in by the compiler.</param>
    protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}