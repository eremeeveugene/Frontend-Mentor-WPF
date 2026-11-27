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

using FrontendMentor.Assets.MarkupExtensions;
using System.Globalization;
using System.Windows.Data;

namespace FrontendMentor.Assets.Converters;

/// <summary>
///     Converts a value to <c>true</c> when it equals the converter parameter, and back to the parameter when it is
///     <c>true</c>. It binds a group of radio buttons to one value.
/// </summary>
[ValueConversion(typeof(object), typeof(bool))]
public sealed class EqualityParameterToBooleanConverter : ConverterMarkupExtension<EqualityParameterToBooleanConverter>
{
    /// <inheritdoc />
    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Equals(value, parameter);
    }

    /// <inheritdoc />
    public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is true ? parameter : Binding.DoNothing;
    }
}