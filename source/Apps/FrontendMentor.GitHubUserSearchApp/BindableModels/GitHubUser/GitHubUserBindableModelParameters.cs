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

using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;

namespace FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;

/// <summary>
///     The parameters that are needed to create the bindable model of a GitHub user.
/// </summary>
internal sealed class GitHubUserBindableModelParameters
{
    public GitHubUserBindableModelParameters(GitHubUserModel gitHubUser)
    {
        GitHubUser = gitHubUser;
    }

    /// <summary>
    ///     Gets the git hub user.
    /// </summary>
    public GitHubUserModel GitHubUser { get; }
}