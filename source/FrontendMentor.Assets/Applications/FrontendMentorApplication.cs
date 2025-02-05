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

using FrontendMentor.Assets.Constants;
using FrontendMentor.Assets.Controls.Windows;
using FrontendMentor.Assets.Enums;
using FrontendMentor.Assets.Services.Themes;
using FrontendMentor.Core.Applications;
using System.Windows;

namespace FrontendMentor.Assets.Applications;

public abstract class FrontendMentorApplication : FrontendMentorCoreApplication
{
    private IRegionManager _regionManager = null!;

    protected override Window CreateShell()
    {
        return Container.Resolve<FrontendMentorWindow>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _regionManager = Container.Resolve<IRegionManager>();

        var themeService = Container.Resolve<IThemeService>();

        // ToDo: Get system value
        themeService.SetTheme(Theme.Light);
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterSingleton<IThemeService, ThemeService>();
    }

    protected void NavigateToShellRegion(string viewName)
    {
        _regionManager.RequestNavigate(FrontedMentorRegionNames.Shell, viewName);
    }
}