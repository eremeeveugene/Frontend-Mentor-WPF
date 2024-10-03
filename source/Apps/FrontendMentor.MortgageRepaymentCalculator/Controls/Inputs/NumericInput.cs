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

using FrontendMentor.Assets.Enums;
using System.Windows;
using System.Windows.Controls;

namespace FrontendMentor.MortgageRepaymentCalculator.Controls.Inputs;

internal class NumericInput : Control
{
    public static readonly DependencyProperty TextBoxInputTypeProperty = DependencyProperty.Register(
        nameof(TextBoxInputType), typeof(TextBoxInputType), typeof(NumericInput),
        new PropertyMetadata(default(TextBoxInputType), OnTextBoxInputTypeChanged));

    public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(
        nameof(Format), typeof(string), typeof(NumericInput), new PropertyMetadata(default(string), OnFormatChanged));

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value), typeof(double), typeof(NumericInput),
        new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnValueChanged));

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text), typeof(string), typeof(NumericInput),
        new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnTextChanged));

    public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
        nameof(Caption), typeof(string), typeof(NumericInput), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty PrefixProperty = DependencyProperty.Register(
        nameof(Prefix), typeof(string), typeof(NumericInput), new PropertyMetadata(default(string?)));

    public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
        nameof(Suffix), typeof(string), typeof(NumericInput), new PropertyMetadata(default(string?)));

    public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(
        nameof(Placeholder), typeof(string), typeof(NumericInput), new PropertyMetadata(default(string)));

    static NumericInput()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericInput),
            new FrameworkPropertyMetadata(typeof(NumericInput)));
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string? Prefix
    {
        get => (string?)GetValue(PrefixProperty);
        set => SetValue(PrefixProperty, value);
    }

    public string? Suffix
    {
        get => (string?)GetValue(SuffixProperty);
        set => SetValue(SuffixProperty, value);
    }

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public string Caption
    {
        get => (string)GetValue(CaptionProperty);
        set => SetValue(CaptionProperty, value);
    }

    public TextBoxInputType TextBoxInputType
    {
        get => (TextBoxInputType)GetValue(TextBoxInputTypeProperty);
        set => SetValue(TextBoxInputTypeProperty, value);
    }

    public string Format
    {
        get => (string)GetValue(FormatProperty);
        set => SetValue(FormatProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericInput)d;
        control.OnTextChanged((string)e.NewValue);
    }

    private void OnTextChanged(string newText)
    {
        // Sync the text to value, considering TextBoxInputType and Format.
        if (double.TryParse(newText, out var result))
        {
            Value = result;
        }
    }

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericInput)d;
        control.OnValueChanged((double)e.NewValue);
    }

    private void OnValueChanged(double newValue)
    {
        // Apply the format and update the Text.
        Text = string.IsNullOrEmpty(Format) ? newValue.ToString() : newValue.ToString(Format);
    }

    private static void OnTextBoxInputTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericInput)d;
        // Adjust input restrictions based on the type (e.g., integer or decimal).
    }

    private static void OnFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericInput)d;
        control.OnValueChanged(control.Value); // Reapply format when format changes.
    }
}