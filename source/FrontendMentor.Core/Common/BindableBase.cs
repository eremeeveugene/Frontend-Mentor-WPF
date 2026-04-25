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

namespace FrontendMentor.Core.Common;

public abstract class BindableBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    ///     Sets the backing field and raises <see cref="PropertyChanged" /> if the value changed.
    /// </summary>
    protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        return SetProperty(ref storage, value, null, propertyName);
    }

    /// <summary>
    ///     Sets the backing field, invokes <paramref name="onChanged" />,
    ///     and raises <see cref="PropertyChanged" /> if the value changed.
    /// </summary>
    protected virtual bool SetProperty<T>(
        ref T storage,
        T value,
        Action? onChanged,
        [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value))
        {
            return false;
        }

        storage = value;

        onChanged?.Invoke();

        OnPropertyChanged(propertyName);

        return true;
    }

    /// <summary>
    ///     Raises <see cref="PropertyChanged" /> for the specified property.
    /// </summary>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}