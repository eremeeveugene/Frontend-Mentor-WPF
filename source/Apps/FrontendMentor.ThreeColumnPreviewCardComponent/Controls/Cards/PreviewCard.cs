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

namespace FrontendMentor.ThreeColumnPreviewCardComponent.Controls.Cards;

internal class PreviewCard : Control
{
    public static readonly DependencyProperty IconFillProperty = DependencyProperty.Register(
        nameof(IconFill), typeof(Brush), typeof(PreviewCard), new PropertyMetadata(default(Brush)));

    public static readonly DependencyProperty IconDataProperty = DependencyProperty.Register(
        nameof(IconData), typeof(Geometry), typeof(PreviewCard), new PropertyMetadata(default(Geometry)));

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius), typeof(CornerRadius), typeof(PreviewCard), new PropertyMetadata(default(CornerRadius)));

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(PreviewCard), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
        nameof(Caption), typeof(string), typeof(PreviewCard), new PropertyMetadata(default(string)));
    
    static PreviewCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PreviewCard),
            new FrameworkPropertyMetadata(typeof(PreviewCard)));
    }

    public Brush IconFill
    {
        get => (Brush)GetValue(IconFillProperty);
        set => SetValue(IconFillProperty, value);
    }

    public Geometry IconData
    {
        get => (Geometry)GetValue(IconDataProperty);
        set => SetValue(IconDataProperty, value);
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Caption
    {
        get => (string)GetValue(CaptionProperty);
        set => SetValue(CaptionProperty, value);
    }
}