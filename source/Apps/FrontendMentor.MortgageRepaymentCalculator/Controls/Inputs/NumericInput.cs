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

using FrontendMentor.Assets.Enums;
using System.Windows;
using System.Windows.Controls;

namespace FrontendMentor.MortgageRepaymentCalculator.Controls.Inputs;

internal class NumericInput : Control
{
    public static readonly DependencyProperty TextBoxInputTypeProperty = DependencyProperty.Register(
        nameof(TextBoxInputType), typeof(TextBoxInputType), typeof(NumericInput),
        new PropertyMetadata(default(TextBoxInputType)));

    public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(
        nameof(Format), typeof(string), typeof(NumericInput), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text), typeof(string), typeof(NumericInput),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            (o, _) => ((NumericInput)o).OnTextChanged()));

    public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
        nameof(Caption), typeof(string), typeof(NumericInput), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty PrefixProperty = DependencyProperty.Register(
        nameof(Prefix), typeof(string), typeof(NumericInput), new PropertyMetadata(null));

    public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
        nameof(Suffix), typeof(string), typeof(NumericInput), new PropertyMetadata(null));

    public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(
        nameof(Placeholder), typeof(string), typeof(NumericInput), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(
        nameof(MaxLength), typeof(int), typeof(NumericInput), new PropertyMetadata(default(int)));

    static NumericInput()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericInput),
            new FrameworkPropertyMetadata(typeof(NumericInput)));
    }

    public int MaxLength
    {
        get => (int)GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    public string? Text
    {
        get => (string?)GetValue(TextProperty);
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

    private void OnTextChanged()
    {
    }
}