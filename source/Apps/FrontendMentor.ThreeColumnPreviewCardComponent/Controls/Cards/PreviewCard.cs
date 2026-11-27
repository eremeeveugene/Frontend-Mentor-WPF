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

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FrontendMentor.ThreeColumnPreviewCardComponent.Controls.Cards;

/// <summary>
///     A card with an icon, a title and a caption.
/// </summary>
internal sealed class PreviewCard : Control
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

    /// <summary>
    ///     Gets or sets the brush that fills the icon.
    /// </summary>
    public Brush IconFill
    {
        get => (Brush)GetValue(IconFillProperty);
        set => SetValue(IconFillProperty, value);
    }

    /// <summary>
    ///     Gets or sets the geometry of the icon.
    /// </summary>
    public Geometry IconData
    {
        get => (Geometry)GetValue(IconDataProperty);
        set => SetValue(IconDataProperty, value);
    }

    /// <summary>
    ///     Gets or sets the radius of the card corners.
    /// </summary>
    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    /// <summary>
    ///     Gets or sets the title.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    ///     Gets or sets the caption.
    /// </summary>
    public string Caption
    {
        get => (string)GetValue(CaptionProperty);
        set => SetValue(CaptionProperty, value);
    }
}