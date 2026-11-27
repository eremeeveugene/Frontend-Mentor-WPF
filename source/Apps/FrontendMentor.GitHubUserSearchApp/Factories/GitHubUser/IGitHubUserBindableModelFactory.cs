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

using FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;
using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;

namespace FrontendMentor.GitHubUserSearchApp.Factories.GitHubUser;

/// <summary>
///     Creates the presentation models of GitHub users.
/// </summary>
internal interface IGitHubUserBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of a GitHub user.
    /// </summary>
    /// <param name="gitHubUser">The data of a GitHub user.</param>
    /// <returns>The presentation model.</returns>
    IGitHubUserBindableModel Create(GitHubUserModel gitHubUser);
}