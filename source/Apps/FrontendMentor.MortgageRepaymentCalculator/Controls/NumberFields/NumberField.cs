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

using System.Windows;
using System.Windows.Controls;

namespace FrontendMentor.MortgageRepaymentCalculator.Controls.NumberFields;

/// <summary>
///     A text box for a number, with a header and a unit before or after the number. Its style shows the validation
///     error of its binding below it and limits the input to number characters.
/// </summary>
internal sealed class NumberField : TextBox
{
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(Header), typeof(string), typeof(NumberField), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty AffixProperty = DependencyProperty.Register(
        nameof(Affix), typeof(string), typeof(NumberField), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty AffixPlacementProperty = DependencyProperty.Register(
        nameof(AffixPlacement), typeof(Dock), typeof(NumberField), new PropertyMetadata(Dock.Left));

    static NumberField()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberField),
            new FrameworkPropertyMetadata(typeof(NumberField)));
    }

    /// <summary>
    ///     Gets or sets the header above the field.
    /// </summary>
    public string? Header
    {
        get => (string?)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    ///     Gets or sets the unit that is shown next to the number, such as £ or %.
    /// </summary>
    public string? Affix
    {
        get => (string?)GetValue(AffixProperty);
        set => SetValue(AffixProperty, value);
    }

    /// <summary>
    ///     Gets or sets the side of the number that the unit is shown on.
    /// </summary>
    public Dock AffixPlacement
    {
        get => (Dock)GetValue(AffixPlacementProperty);
        set => SetValue(AffixPlacementProperty, value);
    }
}