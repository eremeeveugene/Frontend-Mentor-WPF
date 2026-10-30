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

using FrontendMentor.Core.Extensions;
using FrontendMentor.SocialLinksProfile.BindableModels.SocialLink;
using FrontendMentor.SocialLinksProfile.BindableModels.SocialLinkProfile;
using FrontendMentor.SocialLinksProfile.Controls.Windows;
using FrontendMentor.SocialLinksProfile.Models;
using FrontendMentor.SocialLinksProfile.Services.SocialLinkProfiles;
using FrontendMentor.SocialLinksProfile.ViewModels.SocialLinksProfile;
using FrontendMentor.SocialLinksProfile.Views.SocialLinksProfile;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.SocialLinksProfile;

/// <summary>
///     The application entry point.
/// </summary>
internal sealed partial class App
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddTransient<ISocialLinkProfilesService, SocialLinkProfilesService>()
            .AddFactory<SocialLinkProfileBindableModelParameters, ISocialLinkProfileBindableModel, SocialLinkProfileBindableModel>()
            .AddFactory<SocialLinkBindableModelParameters, ISocialLinkBindableModel, SocialLinkBindableModel>()
            .AddTransient<ISocialLinksProfileViewModel, SocialLinksProfileViewModel>()
            .AddMainWindow<ISocialLinksProfileWindow, SocialLinksProfileWindow>()
            .AddTransient<ISocialLinksProfileView, SocialLinksProfileView>();
    }
}