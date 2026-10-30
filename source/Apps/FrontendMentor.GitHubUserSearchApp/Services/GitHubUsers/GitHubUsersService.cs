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
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace FrontendMentor.GitHubUserSearchApp.Services.GitHubUsers;

/// <inheritdoc />
internal sealed class GitHubUsersService : IGitHubUsersService
{
    private readonly HttpClient _httpClient;

    public GitHubUsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public async Task<GitHubUserModel?> GetUserAsync(string username, CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync($"users/{Uri.EscapeDataString(username)}", cancellationToken);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GitHubUserModel>(cancellationToken);
    }
}