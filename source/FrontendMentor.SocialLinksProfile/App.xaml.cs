// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Core.Services.Sectors;
using FrontendMentor.Core.Services.SectorsContainerRegistry;
using FrontendMentor.SocialLinksProfile.Constants;
using FrontendMentor.SocialLinksProfile.Controls.Windows;
using FrontendMentor.SocialLinksProfile.Services.SocialLinksProfiles;
using FrontendMentor.SocialLinksProfile.Views;
using Prism.Ioc;
using System.Windows;

namespace FrontendMentor.SocialLinksProfile;

public partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.Register<ISocialLinksProfilesService, SocialLinksProfilesService>();

        containerRegistry.RegisterSector<SocialLinksProfileView>(SocialLinksProfileSectorNames
            .SocialLinksProfileSector);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<SocialLinksProfileWindow>();
    }

    protected override void OnInitialized()
    {
        var sectorsService = Container.Resolve<ISectorsService>();

        sectorsService.NavigateToSector(SocialLinksProfileSectorNames.SocialLinksProfileSector);

        base.OnInitialized();
    }
}