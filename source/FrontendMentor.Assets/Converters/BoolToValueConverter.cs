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

public class BoolToValueConverter<T> : ConverterMarkupExtension<BoolToValueConverter<T>>, IValueConverter
{
    public bool Invert { get; set; }
    public virtual T? TrueValue { get; set; }
    public virtual T? FalseValue { get; set; }

    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not bool boolValue)
        {
            throw new InvalidTypeException<bool>();
        }

        if (Invert)
        {
            return boolValue ? FalseValue : TrueValue;
        }

        return boolValue ? TrueValue : FalseValue;
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