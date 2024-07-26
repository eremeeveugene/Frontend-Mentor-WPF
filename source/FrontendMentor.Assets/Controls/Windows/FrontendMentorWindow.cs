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

using Prism.Commands;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FrontendMentor.Assets.Controls.Windows;

public class FrontendMentorWindow : Window
{
    public static readonly DependencyProperty TitleBarBackgroundProperty = DependencyProperty.Register(
        nameof(TitleBarBackground), typeof(Brush), typeof(FrontendMentorWindow), new PropertyMetadata(default(Brush)));

    public static readonly DependencyProperty TitleBarHeightProperty = DependencyProperty.Register(
        nameof(TitleBarHeight), typeof(double), typeof(FrontendMentorWindow), new PropertyMetadata(default(double)));

    private ICommand? _closeCommand;
    private ICommand? _minimizeCommand;
    private ICommand? _toggleMaximizeCommand;

    static FrontendMentorWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FrontendMentorWindow),
            new FrameworkPropertyMetadata(typeof(FrontendMentorWindow)));
    }

    public double TitleBarHeight
    {
        get => (double)GetValue(TitleBarHeightProperty);
        set => SetValue(TitleBarHeightProperty, value);
    }

    public Brush TitleBarBackground
    {
        get => (Brush)GetValue(TitleBarBackgroundProperty);
        set => SetValue(TitleBarBackgroundProperty, value);
    }

    public ICommand MinimizeCommand => _minimizeCommand ??= new DelegateCommand(Minimize);
    public ICommand ToggleMaximizeCommand => _toggleMaximizeCommand ??= new DelegateCommand(ToggleMaximize);
    public ICommand CloseCommand => _closeCommand ??= new DelegateCommand(Close);

    private void ToggleMaximize()
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    private void Minimize()
    {
        WindowState = WindowState.Minimized;
    }
}