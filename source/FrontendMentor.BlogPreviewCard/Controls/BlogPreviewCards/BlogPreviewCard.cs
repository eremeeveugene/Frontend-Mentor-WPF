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

namespace FrontendMentor.BlogPreviewCard.Controls.BlogPreviewCards;

internal class BlogPreviewCard : Control
{
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius), typeof(CornerRadius), typeof(BlogPreviewCard),
        new PropertyMetadata(default(CornerRadius)));

    public static readonly DependencyProperty BlogProperty = DependencyProperty.Register(
        nameof(Blog), typeof(IBlog), typeof(BlogPreviewCard), new PropertyMetadata(default(IBlog)));

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

    public IBlog Blog
    {
        get => (IBlog)GetValue(BlogProperty);
        set => SetValue(BlogProperty, value);
    }
}