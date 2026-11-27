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
///     Reads the theme that Windows uses for applications.
/// </summary>
public interface ISystemThemeService
{
    /// <summary>
    ///     Gets the theme that the user chose for applications in the Windows settings.
    /// </summary>
    /// <returns>The theme of the system, or <see cref="Theme.Light" /> when Windows has no such setting.</returns>
    Theme GetSystemTheme();
}