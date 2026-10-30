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

using FrontendMentor.Core.Views;
using System.Windows;

namespace FrontendMentor.Assets.Controls.Windows;

/// <summary>
///     The base window of the Frontend Mentor applications. It has a themed frame and
///     shows a view as its content.
/// </summary>
public abstract class FrontendMentorWindow : Window
{
    static FrontendMentorWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FrontendMentorWindow),
            new FrameworkPropertyMetadata(typeof(FrontendMentorWindow)));
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="FrontendMentorWindow" /> class.
    /// </summary>
    /// <param name="view">The view that the window shows as its content.</param>
    protected FrontendMentorWindow(IView view)
    {
        Content = view;
    }
}