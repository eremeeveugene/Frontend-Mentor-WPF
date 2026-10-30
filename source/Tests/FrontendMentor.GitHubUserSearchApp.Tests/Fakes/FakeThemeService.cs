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
using FrontendMentor.Assets.Services.Themes;

namespace FrontendMentor.GitHubUserSearchApp.Tests.Fakes;

/// <summary>
///     A theme service that only remembers the theme that was set.
/// </summary>
internal sealed class FakeThemeService : IThemeService
{
    public Theme CurrentTheme { get; private set; } = Theme.Light;

    public void SetTheme(Theme theme)
    {
        CurrentTheme = theme;
    }
}