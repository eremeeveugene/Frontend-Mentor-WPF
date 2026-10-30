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
using FrontendMentor.ResultsSummaryComponent.Enums;
using System.Globalization;
using System.Windows;

namespace FrontendMentor.ResultsSummaryComponent.Converters;

/// <summary>
///     Converts a summary item type to the value that is configured for it.
/// </summary>
internal sealed class SummaryItemTypeToValueConverter : ConverterMarkupExtension<SummaryItemTypeToValueConverter>
{
    /// <summary>
    ///     Gets or sets the value for the memory summary item type.
    /// </summary>
    public object? MemoryValue { get; set; }
    /// <summary>
    ///     Gets or sets the value for the reaction summary item type.
    /// </summary>
    public object? ReactionValue { get; set; }
    /// <summary>
    ///     Gets or sets the value for the verbal summary item type.
    /// </summary>
    public object? VerbalValue { get; set; }
    /// <summary>
    ///     Gets or sets the value for the visual summary item type.
    /// </summary>
    public object? VisualValue { get; set; }

    /// <inheritdoc />
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