﻿// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.SocialLinksProfile.Constants;
using FrontendMentor.SocialLinksProfile.Controls.Windows;
using FrontendMentor.SocialLinksProfile.Services.SocialLinkProfiles;
using FrontendMentor.SocialLinksProfile.Views;
using System.Windows;

namespace FrontendMentor.SocialLinksProfile;

internal partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.Register<ISocialLinkProfilesService, SocialLinkProfilesService>();
        containerRegistry.RegisterForNavigation<SocialLinksProfileView>(SocialLinksProfileViewNames
            .SocialLinksProfile);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<SocialLinksProfileWindow>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigateToShellRegion(SocialLinksProfileViewNames.SocialLinksProfile);
    }
}