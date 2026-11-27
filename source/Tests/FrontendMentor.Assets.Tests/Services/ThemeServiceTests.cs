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

namespace FrontendMentor.Assets.Tests.Services;

[TestClass]
public sealed class ThemeServiceTests
{
    [STATestMethod]
    public void SetTheme_SetsTheCurrentTheme()
    {
        var themeService = new ThemeService();

        themeService.SetTheme(Theme.Dark);

        Assert.AreEqual(Theme.Dark, themeService.CurrentTheme);
    }

    [STATestMethod]
    public void SetTheme_RaisesThemeChangedAfterTheThemeIsApplied()
    {
        var themeService = new ThemeService();
        var observedThemes = new List<Theme>();

        themeService.ThemeChanged += (_, _) => observedThemes.Add(themeService.CurrentTheme);

        themeService.SetTheme(Theme.Dark);
        themeService.SetTheme(Theme.Light);

        CollectionAssert.AreEqual(new[] { Theme.Dark, Theme.Light }, observedThemes);
    }
}