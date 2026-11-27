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

/// <summary>
///     A resource dictionary whose source is switched when the theme changes.
/// </summary>
/// <remarks>
///     XAML creates these dictionaries, so they cannot be injected into the theme service. Each one registers
///     itself instead, by a weak reference, so that the registration does not keep a dictionary alive.
/// </remarks>
public sealed class ThemeResourceDictionary : ResourceDictionary
{
    private static readonly List<WeakReference<ThemeResourceDictionary>> ThemeResourceDictionaries = [];

    /// <summary>
    ///     Initializes a new instance of the <see cref="ThemeResourceDictionary" /> class.
    /// </summary>
    public ThemeResourceDictionary()
    {
        ThemeResourceDictionaries.Add(new WeakReference<ThemeResourceDictionary>(this));
    }

    /// <summary>
    ///     Gets or sets the source of the dictionary for the light theme.
    /// </summary>
    public Uri? LightThemeSource { get; set; }

    /// <summary>
    ///     Gets or sets the source of the dictionary for the dark theme.
    /// </summary>
    public Uri? DarkThemeSource { get; set; }

    /// <summary>
    ///     Sets the source of every theme resource dictionary that is still alive according to a theme.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    internal static void SetTheme(Theme theme)
    {
        ThemeResourceDictionaries.RemoveAll(static reference => !reference.TryGetTarget(out _));

        foreach (var reference in ThemeResourceDictionaries)
        {
            if (reference.TryGetTarget(out var themeResourceDictionary))
            {
                themeResourceDictionary.ApplyTheme(theme);
            }
        }
    }

    /// <summary>
    ///     Sets the source of the dictionary according to a theme. A source that is already set is not loaded again.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    private void ApplyTheme(Theme theme)
    {
        var source = theme switch
        {
            Theme.Light => LightThemeSource ?? throw new InvalidOperationException("Light theme is not set."),
            Theme.Dark => DarkThemeSource ?? throw new InvalidOperationException("Dark theme is not set."),
            _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
        };

        if (Source != source)
        {
            Source = source;
        }
    }
}