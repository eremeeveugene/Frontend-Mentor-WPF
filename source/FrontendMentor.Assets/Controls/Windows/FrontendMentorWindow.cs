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

using FrontendMentor.Assets.Controls.Windows.Dependencies;
using FrontendMentor.Core.Services.Sectors;
using System.Windows;

namespace FrontendMentor.Assets.Controls.Windows;

public class FrontendMentorWindow : Window
{
    public static readonly DependencyProperty SectorsContainerProperty = DependencyProperty.Register(
        nameof(SectorsContainer), typeof(ISectorsContainer), typeof(FrontendMentorWindow),
        new PropertyMetadata(default(ISectorsContainer)));

    static FrontendMentorWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FrontendMentorWindow),
            new FrameworkPropertyMetadata(typeof(FrontendMentorWindow)));
    }

    public FrontendMentorWindow(FrontendMentorWindowDependencies frontendMentorWindowDependencies)
    {
        SectorsContainer = frontendMentorWindowDependencies.SectorsContainer;
    }

    public ISectorsContainer SectorsContainer
    {
        get => (ISectorsContainer)GetValue(SectorsContainerProperty);
        private set => SetValue(SectorsContainerProperty, value);
    }
}