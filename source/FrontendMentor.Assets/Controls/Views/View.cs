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
using System.Windows.Input;

namespace FrontendMentor.Assets.Controls.Views;

public abstract class View : ContentControl
{
    public static readonly DependencyProperty LoadedCommandProperty = DependencyProperty.Register(
        nameof(LoadedCommand), typeof(ICommand), typeof(View), new PropertyMetadata(default(ICommand)));

    public static readonly DependencyProperty UnloadedCommandProperty = DependencyProperty.Register(
        nameof(UnloadedCommand), typeof(ICommand), typeof(View), new PropertyMetadata(default(ICommand)));

    public static readonly DependencyProperty LoadedCommandParameterProperty = DependencyProperty.Register(
        nameof(LoadedCommandParameter), typeof(object), typeof(View), new PropertyMetadata(default(object)));

    public static readonly DependencyProperty UnloadedCommandParameterProperty = DependencyProperty.Register(
        nameof(UnloadedCommandParameter), typeof(object), typeof(View), new PropertyMetadata(default(object)));

    static View()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(View),
            new FrameworkPropertyMetadata(typeof(View)));
    }

    protected View()
    {
        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    public ICommand? LoadedCommand
    {
        get => (ICommand)GetValue(LoadedCommandProperty);
        set => SetValue(LoadedCommandProperty, value);
    }

    public ICommand? UnloadedCommand
    {
        get => (ICommand)GetValue(UnloadedCommandProperty);
        set => SetValue(UnloadedCommandProperty, value);
    }

    public object? LoadedCommandParameter
    {
        get => GetValue(LoadedCommandParameterProperty);
        set => SetValue(LoadedCommandParameterProperty, value);
    }

    public object? UnloadedCommandParameter
    {
        get => GetValue(UnloadedCommandParameterProperty);
        set => SetValue(UnloadedCommandParameterProperty, value);
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        if (UnloadedCommand != null && UnloadedCommand.CanExecute(UnloadedCommandParameter))
        {
            UnloadedCommand.Execute(UnloadedCommandParameter);
        }
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (LoadedCommand != null && LoadedCommand.CanExecute(LoadedCommandParameter))
        {
            LoadedCommand.Execute(LoadedCommandParameter);
        }
    }
}