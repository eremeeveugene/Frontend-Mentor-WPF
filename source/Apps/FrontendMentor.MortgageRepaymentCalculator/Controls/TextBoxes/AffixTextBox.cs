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

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FrontendMentor.MortgageRepaymentCalculator.Controls.TextBoxes;

internal class AffixTextBox : TextBox
{
    public static readonly DependencyProperty SuffixVisibilityProperty = DependencyProperty.Register(
        nameof(SuffixVisibility), typeof(Visibility), typeof(AffixTextBox), new PropertyMetadata(default(Visibility)));

    public static readonly DependencyProperty PrefixVisibilityProperty = DependencyProperty.Register(
        nameof(PrefixVisibility), typeof(Visibility), typeof(AffixTextBox), new PropertyMetadata(default(Visibility)));

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius), typeof(CornerRadius), typeof(AffixTextBox), new PropertyMetadata(default(CornerRadius)));

    public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
        nameof(Suffix), typeof(string), typeof(AffixTextBox), new PropertyMetadata(default(string?)));

    public static readonly DependencyProperty PrefixProperty = DependencyProperty.Register(
        nameof(Prefix), typeof(string), typeof(AffixTextBox), new PropertyMetadata(default(string?)));

    public static readonly DependencyProperty SuffixBackgroundProperty = DependencyProperty.Register(
        nameof(SuffixBackground), typeof(Brush), typeof(AffixTextBox), new PropertyMetadata(default(Brush)));


    public static readonly DependencyProperty PrefixBackgroundProperty = DependencyProperty.Register(
        nameof(PrefixBackground), typeof(Brush), typeof(AffixTextBox), new PropertyMetadata(default(Brush)));


    public static readonly DependencyProperty PrefixForegroundProperty = DependencyProperty.Register(
        nameof(PrefixForeground), typeof(Brush), typeof(AffixTextBox), new PropertyMetadata(default(Brush)));

    public static readonly DependencyProperty SuffixForegroundProperty = DependencyProperty.Register(
        nameof(SuffixForeground), typeof(Brush), typeof(AffixTextBox), new PropertyMetadata(default(Brush)));

    public static readonly DependencyProperty HasErrorProperty = DependencyProperty.Register(
        nameof(HasError), typeof(bool), typeof(AffixTextBox), new PropertyMetadata(default(bool)));

    static AffixTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AffixTextBox),
            new FrameworkPropertyMetadata(typeof(AffixTextBox)));
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public Visibility SuffixVisibility
    {
        get => (Visibility)GetValue(SuffixVisibilityProperty);
        set => SetValue(SuffixVisibilityProperty, value);
    }

    public Visibility PrefixVisibility
    {
        get => (Visibility)GetValue(PrefixVisibilityProperty);
        set => SetValue(PrefixVisibilityProperty, value);
    }

    public string? Suffix
    {
        get => (string?)GetValue(SuffixProperty);
        set => SetValue(SuffixProperty, value);
    }

    public string? Prefix
    {
        get => (string?)GetValue(PrefixProperty);
        set => SetValue(PrefixProperty, value);
    }

    public Brush SuffixBackground
    {
        get => (Brush)GetValue(SuffixBackgroundProperty);
        set => SetValue(SuffixBackgroundProperty, value);
    }

    public Brush PrefixBackground
    {
        get => (Brush)GetValue(PrefixBackgroundProperty);
        set => SetValue(PrefixBackgroundProperty, value);
    }

    public Brush PrefixForeground
    {
        get => (Brush)GetValue(PrefixForegroundProperty);
        set => SetValue(PrefixForegroundProperty, value);
    }

    public Brush SuffixForeground
    {
        get => (Brush)GetValue(SuffixForegroundProperty);
        set => SetValue(SuffixForegroundProperty, value);
    }

    public bool HasError
    {
        get => (bool)GetValue(HasErrorProperty);
        set => SetValue(HasErrorProperty, value);
    }
}