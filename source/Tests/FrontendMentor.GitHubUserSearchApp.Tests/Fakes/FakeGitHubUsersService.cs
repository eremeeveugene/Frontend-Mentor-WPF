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
using FrontendMentor.GitHubUserSearchApp.Services.GitHubUsers;

namespace FrontendMentor.GitHubUserSearchApp.Tests.Fakes;

/// <summary>
///     A GitHub users service that returns configured users and records the requested logins.
/// </summary>
internal sealed class FakeGitHubUsersService : IGitHubUsersService
{
    private readonly Dictionary<string, GitHubUserModel> _users = new(StringComparer.OrdinalIgnoreCase);

    public List<string> RequestedUsernames { get; } = [];

    public Exception? ExceptionToThrow { get; set; }

    public void AddUser(GitHubUserModel user)
    {
        _users[user.Login] = user;
    }

    public Task<GitHubUserModel?> GetUserAsync(string username, CancellationToken cancellationToken = default)
    {
        RequestedUsernames.Add(username);

        if (ExceptionToThrow != null)
        {
            return Task.FromException<GitHubUserModel?>(ExceptionToThrow);
        }

        return Task.FromResult(_users.GetValueOrDefault(username));
    }
}