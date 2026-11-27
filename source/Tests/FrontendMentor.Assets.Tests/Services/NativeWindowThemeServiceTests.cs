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
using System.Windows;

namespace FrontendMentor.Assets.Tests.Services;

[TestClass]
public sealed class NativeWindowThemeServiceTests
{
    [STATestMethod]
    public void Attach_ObservesTheThemeUntilTheWindowIsClosed()
    {
        var themeService = new ObservedThemeService();
        var window = new Window { Left = -5000, ShowActivated = false, ShowInTaskbar = false };

        new NativeWindowThemeService(themeService).Attach(window);

        Assert.AreEqual(1, themeService.ObserverCount);

        window.Show();
        themeService.SetTheme(Theme.Dark);
        window.Close();

        Assert.AreEqual(0, themeService.ObserverCount, "A closed window must not stay referenced by the theme service.");
    }

    [STATestMethod]
    public void Attach_WindowWithoutNativeWindow_DoesNotThrowWhenTheThemeChanges()
    {
        var themeService = new ObservedThemeService();
        var window = new Window();

        new NativeWindowThemeService(themeService).Attach(window);

        themeService.SetTheme(Theme.Dark);

        Assert.AreEqual(1, themeService.ObserverCount);
    }

    /// <summary>
    ///     A theme service that counts its observers.
    /// </summary>
    private sealed class ObservedThemeService : IThemeService
    {
        private EventHandler? _themeChanged;

        public event EventHandler? ThemeChanged
        {
            add
            {
                _themeChanged += value;
                ObserverCount++;
            }
            remove
            {
                _themeChanged -= value;
                ObserverCount--;
            }
        }

        public int ObserverCount { get; private set; }

        public Theme CurrentTheme { get; private set; } = Theme.Light;

        public void SetTheme(Theme theme)
        {
            CurrentTheme = theme;

            _themeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}