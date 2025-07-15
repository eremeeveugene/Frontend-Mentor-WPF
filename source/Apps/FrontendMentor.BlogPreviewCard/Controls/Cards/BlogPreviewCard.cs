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

using FrontendMentor.BlogPreviewCard.BindableModels;
using System.Windows;
using System.Windows.Controls;

namespace FrontendMentor.BlogPreviewCard.Controls.Cards;

internal class BlogPreviewCard : Control
{
    public static readonly DependencyProperty BlogProperty = DependencyProperty.Register(nameof(Blog),
        typeof(BlogBindableModel), typeof(BlogPreviewCard), new PropertyMetadata(default(BlogBindableModel)));

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius),
        typeof(CornerRadius), typeof(BlogPreviewCard), new PropertyMetadata(default(CornerRadius)));

    static BlogPreviewCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BlogPreviewCard),
            new FrameworkPropertyMetadata(typeof(BlogPreviewCard)));
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public BlogBindableModel Blog
    {
        get => (BlogBindableModel)GetValue(BlogProperty);
        set => SetValue(BlogProperty, value);
    }
}