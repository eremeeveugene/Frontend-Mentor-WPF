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

using FrontendMentor.GitHubUserSearchApp.Constants;
using FrontendMentor.GitHubUserSearchApp.Controls.Windows;
using FrontendMentor.GitHubUserSearchApp.Models.Navigation;
using FrontendMentor.GitHubUserSearchApp.Services.GitHubUsers;
using FrontendMentor.GitHubUserSearchApp.Services.Navigation;
using FrontendMentor.GitHubUserSearchApp.Views;
using System.Windows;

namespace FrontendMentor.GitHubUserSearchApp;

internal partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterSingleton<INavigationService, NavigationService>();
        containerRegistry.RegisterSingleton<IGitHubUsersService, GitHubUsersService>();
        containerRegistry.RegisterForNavigation<GitHubUserSearchAppView>(GitHubUserSearchAppViewNames
            .GitHubUserSearchApp);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<GitHubUserSearchAppWindow>();
    }

    protected override async void OnInitialized()
    {
        base.OnInitialized();

        var gitHubUsersService = Container.Resolve<IGitHubUsersService>();
        var navigationService = Container.Resolve<INavigationService>();

        var gitHubUser = await gitHubUsersService.GetUserAsync("octocat");

        navigationService.NavigateToGitHubUserSearchApp(new GitHubUserSearchAppNavigationParametersModel(gitHubUser));
    }
}