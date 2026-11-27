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

namespace FrontendMentor.GitHubUserSearchApp.Services.GitHubUsers;

/// <summary>
///     Provides GitHub users.
/// </summary>
internal interface IGitHubUsersService
{
    /// <summary>
    ///     Gets a GitHub user by login.
    /// </summary>
    /// <param name="username">The login of the user.</param>
    /// <param name="cancellationToken">The token that cancels the request.</param>
    /// <returns>The user, or <c>null</c> when the user does not exist.</returns>
    Task<GitHubUserModel?> GetUserAsync(string username, CancellationToken cancellationToken = default);
}