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

using System.Globalization;
using System.Windows.Data;

namespace FrontendMentor.Assets.MarkupExtensions;

public abstract class ConverterMarkupExtension<T> : FrontendMentorMarkupExtension<T>, IValueConverter
    where T : class, new()
{
    public abstract object Convert(object? value, Type targetType, object? parameter, CultureInfo culture);
    public abstract object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture);
}