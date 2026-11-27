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

using FrontendMentor.Core.Windows;
using FrontendMentor.SocialLinksProfile.Controls.Windows;
using FrontendMentor.SocialLinksProfile.Factories.SocialLink;
using FrontendMentor.SocialLinksProfile.Factories.SocialLinkProfile;
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

        services.AddTransient<ISocialLinksProfileWindow, SocialLinksProfileWindow>()
            .AddTransient<ISocialLinksProfileView, SocialLinksProfileView>()
            .AddTransient<ISocialLinksProfileViewModel, SocialLinksProfileViewModel>()
            .AddSingleton<ISocialLinkProfilesService, SocialLinkProfilesService>()
            .AddSingleton<ISocialLinkProfileBindableModelFactory, SocialLinkProfileBindableModelFactory>()
            .AddSingleton<ISocialLinkBindableModelFactory, SocialLinkBindableModelFactory>();
    }

    /// <inheritdoc />
    protected override IWindow CreateMainWindow(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<ISocialLinksProfileWindow>();
    }
}