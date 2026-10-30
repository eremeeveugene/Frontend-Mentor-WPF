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

using FrontendMentor.Assets.Enums;
using System.Windows;

namespace FrontendMentor.Assets.Services.Themes;

/// <summary>
///     Applies a theme to the native frame of a window, such as the title bar.
/// </summary>
public interface INativeWindowThemeService
{
    /// <summary>
    ///     Applies a theme to the native frame of a window. When the window is not created yet,
    ///     the theme is applied as soon as it is.
    /// </summary>
    /// <param name="window">The window.</param>
    /// <param name="theme">The theme to apply.</param>
    void SetTheme(Window window, Theme theme);
}