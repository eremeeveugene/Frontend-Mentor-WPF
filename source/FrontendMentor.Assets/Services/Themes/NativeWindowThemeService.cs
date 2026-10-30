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
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace FrontendMentor.Assets.Services.Themes;

/// <inheritdoc />
internal sealed class NativeWindowThemeService : INativeWindowThemeService
{
    private const int DwmwaUseImmersiveDarkMode = 20;
    private const int PreferredAppModeForceDark = 2;
    private const int PreferredAppModeForceLight = 3;

    /// <inheritdoc />
    public void SetTheme(Window window, Theme theme)
    {
        ArgumentNullException.ThrowIfNull(window);

        ApplyMenuTheme(theme);

        var handle = new WindowInteropHelper(window).Handle;

        if (handle != IntPtr.Zero)
        {
            ApplyTheme(handle, theme);

            return;
        }

        void ApplyThemeWhenSourceIsInitialized(object? sender, EventArgs eventArgs)
        {
            window.SourceInitialized -= ApplyThemeWhenSourceIsInitialized;

            ApplyTheme(new WindowInteropHelper(window).Handle, theme);
        }

        window.SourceInitialized += ApplyThemeWhenSourceIsInitialized;
    }

    /// <summary>
    ///     Applies the immersive dark mode attribute to a native window.
    /// </summary>
    /// <param name="handle">The native window handle.</param>
    /// <param name="theme">The theme to apply.</param>
    private static void ApplyTheme(IntPtr handle, Theme theme)
    {
        var useDarkMode = theme switch
        {
            Theme.Light => 0,
            Theme.Dark => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
        };

        // Unsupported Windows versions return a failing HRESULT, so native theming
        // can safely degrade without preventing the XAML theme from being applied.
        _ = DwmSetWindowAttribute(handle, DwmwaUseImmersiveDarkMode, ref useDarkMode, sizeof(int));
    }

    /// <summary>
    ///     Applies the theme to the native menus of the process, such as the system menu of a window.
    ///     The title bar attribute does not change them.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    private static void ApplyMenuTheme(Theme theme)
    {
        var preferredAppMode = theme switch
        {
            Theme.Light => PreferredAppModeForceLight,
            Theme.Dark => PreferredAppModeForceDark,
            _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
        };

        try
        {
            _ = SetPreferredAppMode(preferredAppMode);

            FlushMenuThemes();
        }
        catch (Exception exception) when (exception is EntryPointNotFoundException or DllNotFoundException)
        {
            // These functions are not documented and exist only on newer Windows versions. Without them
            // the native menus keep the theme of the system, and the XAML theme is applied as usual.
        }
    }

    /// <summary>
    ///     Sets the theme that the native menus of the process use. The function is not documented and
    ///     is exported only by its ordinal number.
    /// </summary>
    /// <param name="preferredAppMode">The preferred app mode: 2 for dark and 3 for light.</param>
    /// <returns>The previous preferred app mode.</returns>
    [DllImport("uxtheme.dll", EntryPoint = "#135")]
    private static extern int SetPreferredAppMode(int preferredAppMode);

    /// <summary>
    ///     Makes the native menus pick up the preferred app mode. The function is not documented and
    ///     is exported only by its ordinal number.
    /// </summary>
    [DllImport("uxtheme.dll", EntryPoint = "#136")]
    private static extern void FlushMenuThemes();

    /// <summary>
    ///     Sets an attribute of the desktop window manager for a native window.
    /// </summary>
    /// <param name="windowHandle">The native window handle.</param>
    /// <param name="attribute">The attribute to set.</param>
    /// <param name="attributeValue">The attribute value.</param>
    /// <param name="attributeSize">The size of the attribute value in bytes.</param>
    /// <returns>The result code of the call.</returns>
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(
        IntPtr windowHandle,
        int attribute,
        ref int attributeValue,
        int attributeSize);
}