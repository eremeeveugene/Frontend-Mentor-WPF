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

namespace FrontendMentor.Assets.Services.Themes;

/// <summary>
///     Keeps the native frames of windows, such as their title bars, in the theme of the application.
/// </summary>
public interface INativeWindowThemeService
{
    /// <summary>
    ///     Applies the current theme to the native frame of a window, and applies every later theme until the
    ///     window is closed. When the native window is not created yet, the theme is applied as soon as it is.
    /// </summary>
    /// <param name="window">The window.</param>
    void Attach(Window window);
}