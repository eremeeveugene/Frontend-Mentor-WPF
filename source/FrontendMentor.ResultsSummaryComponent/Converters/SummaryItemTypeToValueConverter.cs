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
using FrontendMentor.ResultsSummaryComponent.Enums;
using System.Globalization;
using System.Windows;

namespace FrontendMentor.ResultsSummaryComponent.Converters;

internal class SummaryItemTypeToValueConverter : ConverterMarkupExtension<SummaryItemTypeToValueConverter>
{
    public object? MemoryValue { get; set; }
    public object? ReactionValue { get; set; }
    public object? VerbalValue { get; set; }
    public object? VisualValue { get; set; }

    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not SummaryItemType summaryItemType)
        {
            throw new InvalidOperationException();
        }

        return summaryItemType switch
        {
            SummaryItemType.Memory => MemoryValue,
            SummaryItemType.Reaction => ReactionValue,
            SummaryItemType.Verbal => VerbalValue,
            SummaryItemType.Visual => VisualValue,
            _ => DependencyProperty.UnsetValue
        };
    }

    public override object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}