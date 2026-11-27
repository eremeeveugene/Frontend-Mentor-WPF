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
using System.Windows.Input;

namespace FrontendMentor.MortgageRepaymentCalculator.Controls.NumberFields;

/// <summary>
///     A text box for a number, with a header, a unit before or after the number, and an error below it.
///     It accepts only digits, decimal points and thousands separators.
/// </summary>
internal sealed class NumberField : TextBox
{
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(Header), typeof(string), typeof(NumberField), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty AffixProperty = DependencyProperty.Register(
        nameof(Affix), typeof(string), typeof(NumberField), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty AffixPlacementProperty = DependencyProperty.Register(
        nameof(AffixPlacement), typeof(Dock), typeof(NumberField), new PropertyMetadata(Dock.Left));

    public static readonly DependencyProperty ErrorProperty = DependencyProperty.Register(
        nameof(Error), typeof(string), typeof(NumberField), new PropertyMetadata(default(string), OnErrorChanged));

    private static readonly DependencyPropertyKey HasErrorPropertyKey = DependencyProperty.RegisterReadOnly(
        nameof(HasError), typeof(bool), typeof(NumberField), new PropertyMetadata(false));

    public static readonly DependencyProperty HasErrorProperty = HasErrorPropertyKey.DependencyProperty;

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

    /// <summary>
    ///     Gets or sets the error below the field, or <c>null</c> when the number is valid.
    /// </summary>
    public string? Error
    {
        get => (string?)GetValue(ErrorProperty);
        set => SetValue(ErrorProperty, value);
    }

    /// <summary>
    ///     Gets a value indicating whether the field shows an error.
    /// </summary>
    public bool HasError => (bool)GetValue(HasErrorProperty);

    /// <summary>
    ///     Gets a value indicating whether the text may be part of a number.
    /// </summary>
    /// <param name="text">The text that is entered.</param>
    /// <returns><c>true</c> when the text has only digits, decimal points and thousands separators.</returns>
    internal static bool IsNumberText(string text)
    {
        foreach (var character in text)
        {
            if (!char.IsAsciiDigit(character) && character != '.' && character != ',')
            {
                return false;
            }
        }

        return true;
    }

    /// <inheritdoc />
    protected override void OnPreviewTextInput(TextCompositionEventArgs e)
    {
        if (!IsNumberText(e.Text))
        {
            e.Handled = true;
        }

        base.OnPreviewTextInput(e);
    }

    private static void OnErrorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        d.SetValue(HasErrorPropertyKey, !string.IsNullOrEmpty((string?)e.NewValue));
    }
}