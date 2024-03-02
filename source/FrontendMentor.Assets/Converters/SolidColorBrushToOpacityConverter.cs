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
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FrontendMentor.Assets.Converters;

[ValueConversion(typeof(SolidColorBrush), typeof(double))]
public class SolidColorBrushToOpacityConverter : ConverterMarkupExtension<SolidColorBrushToOpacityConverter>
{
    public override object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush solidColorBrush)
        {
            return solidColorBrush.Opacity;
        }

        return new InvalidOperationException();
    }

    public override object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}