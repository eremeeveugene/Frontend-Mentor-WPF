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

using FrontendMentor.Assets.Enums;
using System.Windows;

namespace FrontendMentor.Assets.ResourceDictionaries;

public sealed class ThemeResourceDictionary : ResourceDictionary
{
    public ThemeResourceDictionary()
    {
        ThemeResourceDictionaries.Add(this);
    }

    private static List<ThemeResourceDictionary> ThemeResourceDictionaries { get; } = [];
    public Uri? LightThemeSource { get; set; }
    public Uri? DarkThemeSource { get; set; }

    public static void SetTheme(Theme theme)
    {
        foreach (var themeResourceDictionary in ThemeResourceDictionaries)
        {
            themeResourceDictionary.Source = theme switch
            {
                Theme.Light => themeResourceDictionary.LightThemeSource ??
                               throw new InvalidOperationException("Light theme is not set."),
                Theme.Dark => themeResourceDictionary.DarkThemeSource ??
                              throw new InvalidOperationException("Dark theme is not set."),
                _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
            };
        }
    }
}