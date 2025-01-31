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

using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;
using Newtonsoft.Json;
using System.Net.Http;

namespace FrontendMentor.GitHubUserSearchApp.Services.GitHubUsers;

internal sealed class GitHubUsersService : IGitHubUsersService
{
    private static readonly HttpClient _httpClient = new();

    public async Task<GitHubUserModel> GetUserAsync(string username)
    {
        var url = $"https://api.github.com/users/{username}";

        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("WPFApp"); // GitHub API requires a User-Agent header

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error fetching GitHub user: {response.StatusCode}");
        }

        var json = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<GitHubUserModel>(json);
    }
}