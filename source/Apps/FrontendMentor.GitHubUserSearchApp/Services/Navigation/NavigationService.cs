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
using FrontendMentor.GitHubUserSearchApp.Constants;
using FrontendMentor.GitHubUserSearchApp.Models.Navigation;

namespace FrontendMentor.GitHubUserSearchApp.Services.Navigation;

internal sealed class NavigationService(IRegionManager regionManager) : INavigationService
{
    public void NavigateToGitHubUserSearchApp(GitHubUserSearchAppNavigationParametersModel parameters)
    {
        regionManager.RequestNavigate(FrontedMentorRegionNames.Shell, GitHubUserSearchAppViewNames.GitHubUserSearchApp,
            new NavigationParameters { { nameof(GitHubUserSearchAppNavigationParametersModel), parameters } });
    }
}