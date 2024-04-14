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
using FrontendMentor.Core.Attributes;
using System.ComponentModel;
using System.Globalization;

namespace FrontendMentor.Assets.Converters;

public class EnumToDescriptionConverter : ConverterMarkupExtension<EnumToDescriptionConverter>
{
    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return null;
        }

        var fieldName = value.ToString() ?? throw new InvalidOperationException();

        var fieldInfo = value.GetType().GetField(fieldName);

        if (fieldInfo == null)
        {
            return value.ToString();
        }

        if (fieldInfo.GetCustomAttributes(typeof(LocalizedDescriptionAttribute), false)
                .FirstOrDefault() is LocalizedDescriptionAttribute localizedDescription)
        {
            return localizedDescription.Description;
        }

        if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() is DescriptionAttribute description)
        {
            return description.Description;
        }

        return value.ToString();
    }

    public override object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}