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
using Microsoft.Win32;

namespace FrontendMentor.Assets.Services.Themes;

/// <inheritdoc />
internal sealed class SystemThemeService : ISystemThemeService
{
    private const string AppsUseLightThemeValueName = "AppsUseLightTheme";
    private const string PersonalizeKeyName = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

    /// <inheritdoc />
    public Theme GetSystemTheme()
    {
        using var personalizeKey = Registry.CurrentUser.OpenSubKey(PersonalizeKeyName);

        return ToTheme(personalizeKey?.GetValue(AppsUseLightThemeValueName));
    }

    /// <summary>
    ///     Converts the registry value that tells whether applications use the light theme.
    /// </summary>
    /// <param name="appsUseLightTheme">The value: 0 for dark, 1 for light, or <c>null</c> when it does not exist.</param>
    /// <returns>The theme. Windows uses the light theme when the value does not exist.</returns>
    internal static Theme ToTheme(object? appsUseLightTheme)
    {
        return appsUseLightTheme is 0 ? Theme.Dark : Theme.Light;
    }
}