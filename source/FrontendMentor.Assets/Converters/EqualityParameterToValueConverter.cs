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

using FrontendMentor.Assets.MarkupExtensions;
using System.Globalization;
using System.Windows.Data;

namespace FrontendMentor.Assets.Converters;

[ValueConversion(typeof(object), typeof(object))]
/// <summary>
///     Converts a value to one of two values, depending on whether it equals the converter parameter.
/// </summary>
public sealed class EqualityParameterToValueConverter : ConverterMarkupExtension<EqualityParameterToValueConverter>
{
    /// <summary>
    ///     Gets or sets the value that is returned when the value equals the parameter.
    /// </summary>
    public object? TrueValue { get; set; }
    /// <summary>
    ///     Gets or sets the value that is returned when the value does not equal the parameter.
    /// </summary>
    public object? FalseValue { get; set; }

    /// <inheritdoc />
    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value != null && value.Equals(parameter))
        {
            return TrueValue;
        }

        return FalseValue;
    }

    /// <inheritdoc />
    public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    /// <inheritdoc />
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}