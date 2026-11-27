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
using FrontendMentor.Assets.ResourceDictionaries;

namespace FrontendMentor.Assets.Services.Themes;

/// <inheritdoc />
internal sealed class ThemeService : IThemeService
{
    /// <inheritdoc />
    public event EventHandler? ThemeChanged;

    /// <inheritdoc />
    public Theme CurrentTheme { get; private set; } = Theme.Light;

    /// <inheritdoc />
    public void SetTheme(Theme theme)
    {
        ThemeResourceDictionary.SetTheme(theme);

        CurrentTheme = theme;

        ThemeChanged?.Invoke(this, EventArgs.Empty);
    }
}