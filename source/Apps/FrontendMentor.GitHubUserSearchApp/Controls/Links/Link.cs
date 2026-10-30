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
using System.Windows.Media;

namespace FrontendMentor.GitHubUserSearchApp.Controls.Links;

/// <summary>
///     A link with an icon that shows a text, or a placeholder when there is no text.
/// </summary>
internal sealed class Link : Control
{
    public static readonly DependencyProperty GeometryProperty = DependencyProperty.Register(
        nameof(Geometry), typeof(Geometry), typeof(Link), new PropertyMetadata(default(Geometry)));

    public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
        nameof(Source), typeof(string), typeof(Link), new PropertyMetadata(default(string)));

    static Link()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Link),
            new FrameworkPropertyMetadata(typeof(Link)));
    }

    /// <summary>
    ///     Gets or sets the geometry of the icon.
    /// </summary>
    public Geometry Geometry
    {
        get => (Geometry)GetValue(GeometryProperty);
        set => SetValue(GeometryProperty, value);
    }

    /// <summary>
    ///     Gets or sets the text of the link.
    /// </summary>
    public string? Source
    {
        get => (string?)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }
}