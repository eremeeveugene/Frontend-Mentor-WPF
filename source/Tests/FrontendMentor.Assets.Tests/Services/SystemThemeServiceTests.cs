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
public sealed class SystemThemeServiceTests
{
    [TestMethod]
    public void ToTheme_Zero_IsDark()
    {
        Assert.AreEqual(Theme.Dark, SystemThemeService.ToTheme(0));
    }

    [TestMethod]
    public void ToTheme_One_IsLight()
    {
        Assert.AreEqual(Theme.Light, SystemThemeService.ToTheme(1));
    }

    [TestMethod]
    public void ToTheme_MissingOrUnexpectedValue_IsLight()
    {
        Assert.AreEqual(Theme.Light, SystemThemeService.ToTheme(null));
        Assert.AreEqual(Theme.Light, SystemThemeService.ToTheme("0"));
    }

    [TestMethod]
    public void GetSystemTheme_ReturnsATheme()
    {
        var theme = new SystemThemeService().GetSystemTheme();

        Assert.IsTrue(Enum.IsDefined(theme));
    }
}