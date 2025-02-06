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
using System.Windows.Input;
using System.Windows.Media;

namespace FrontendMentor.GitHubUserSearchApp.Controls.Links;

internal class Link : Control
{
    public static readonly DependencyProperty GeometryProperty = DependencyProperty.Register(
        nameof(Geometry), typeof(Geometry), typeof(Link), new PropertyMetadata(default(Geometry)));

    public static readonly DependencyProperty NavigateCommandProperty = DependencyProperty.Register(
        nameof(NavigateCommand), typeof(ICommand), typeof(Link), new PropertyMetadata(default(ICommand)));
    
    public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
        nameof(Source), typeof(string), typeof(Link), new PropertyMetadata(default(string)));

    static Link()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Link),
            new FrameworkPropertyMetadata(typeof(Link)));
    }

    public Geometry Geometry
    {
        get => (Geometry)GetValue(GeometryProperty);
        set => SetValue(GeometryProperty, value);
    }

    public ICommand NavigateCommand
    {
        get => (ICommand)GetValue(NavigateCommandProperty);
        set => SetValue(NavigateCommandProperty, value);
    }

    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }
}