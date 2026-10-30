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

namespace FrontendMentor.Assets.Services.Themes;

/// <summary>
///     Switches the theme of the application.
/// </summary>
public interface IThemeService
{
    /// <summary>
    ///     Gets the theme that is currently applied.
    /// </summary>
    Theme CurrentTheme { get; }

    /// <summary>
    ///     Applies a theme to the resources and to the native frames of all windows.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    void SetTheme(Theme theme);
}