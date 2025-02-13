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

namespace FrontendMentor.ProfileCardComponent.Converters;

[ValueConversion(typeof(int), typeof(string))]
public class NumberAbbreviationConverter : ConverterMarkupExtension<NumberAbbreviationConverter>
{
    public override object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not double && value is not int && value is not long && value is not float && value is not decimal)
        {
            throw new NotSupportedException();
        }

        var number = System.Convert.ToDecimal(value);

        return number switch
        {
            >= 1_000_000_000 => (number / 1_000_000_000).ToString("0.#") + "B",
            >= 1_000_000 => (number / 1_000_000).ToString("0.#") + "M",
            >= 1_000 => (number / 1_000).ToString("0.#") + "K",
            _ => number.ToString("0")
        };
    }

    public override object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}