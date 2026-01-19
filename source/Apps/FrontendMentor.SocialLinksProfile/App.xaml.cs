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

using FrontendMentor.SocialLinksProfile.Constants;
using FrontendMentor.SocialLinksProfile.Controls.Windows;
using FrontendMentor.SocialLinksProfile.Services.SocialLinkProfiles;
using FrontendMentor.SocialLinksProfile.Views;
using Splat;
using System.Windows;

namespace FrontendMentor.SocialLinksProfile;

internal partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

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

    protected override void RegisterServices(IMutableDependencyResolver locator)
    {
        base.RegisterTypes(locator);

        locator.RegisterLazySingleton<ISocialLinkProfilesService>(() => new SocialLinkProfilesService());


        locator.RegisterLazySingleton<FrontendMentorWindowViewModel>(
            () => new FrontendMentorWindowViewModel());

        locator.Register(() =>
        {
            var shell = Locator.Current.GetService<FrontendMentorWindowViewModel>()!;
            return new BlogPreviewCardViewModel(shell);
        }, typeof(BlogPreviewCardViewModel));
    }

    protected override void OnShellStarted(FrontendMentorWindowViewModel shell)
    {
        var first = Locator.Current.GetService<BlogPreviewCardViewModel>()!;

        shell.Router.Navigate.Execute(first).Subscribe();
    }
}