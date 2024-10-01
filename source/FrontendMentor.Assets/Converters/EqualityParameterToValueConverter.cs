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

using FrontendMentor.Assets.MarkupExtensions;
using FrontendMentor.Core.Exceptions;
using System.Globalization;
using System.Windows.Data;

namespace FrontendMentor.Assets.Converters;

[ValueConversion(typeof(object), typeof(object))]
public class EqualityParameterToValueConverter : ConverterMarkupExtension<EqualityParameterToValueConverter>
{
    public object? TrueValue { get; set; }
    public object? FalseValue { get; set; }

    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null && parameter == null)
        {
            return TrueValue;
        }

        if (value == null || parameter == null)
        {
            return FalseValue;
        }

        return value.Equals(parameter) ? TrueValue : FalseValue;
    }

    public override object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new ConvertBackNotSupportedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}