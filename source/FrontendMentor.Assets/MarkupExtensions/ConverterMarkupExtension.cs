// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using System.Globalization;
using System.Windows.Data;

namespace FrontendMentor.Assets.MarkupExtensions;

/// <summary>
///     The base class for value converters that are used directly as markup extensions.
/// </summary>
public abstract class ConverterMarkupExtension<T> : LazyMarkupExtension<T>, IValueConverter where T : class, new()
{
    /// <inheritdoc />
    public abstract object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture);
    /// <inheritdoc />
    public abstract object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture);
}