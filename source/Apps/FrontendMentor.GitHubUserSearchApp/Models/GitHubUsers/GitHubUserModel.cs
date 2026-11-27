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

using System.Text.Json.Serialization;

namespace FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;

/// <summary>
///     The data of a GitHub user as returned by the GitHub API.
/// </summary>
internal sealed class GitHubUserModel
{
    [JsonPropertyName("login")] public required string Login { get; init; }

    [JsonPropertyName("name")] public string? Name { get; init; }

    [JsonPropertyName("avatar_url")] public required string AvatarUrl { get; init; }

    [JsonPropertyName("location")] public string? Location { get; init; }

    [JsonPropertyName("blog")] public string? Blog { get; init; }

    [JsonPropertyName("bio")] public string? Bio { get; init; }

    [JsonPropertyName("twitter_username")] public string? TwitterUsername { get; init; }

    [JsonPropertyName("company")] public string? Company { get; init; }

    [JsonPropertyName("public_repos")] public int PublicRepos { get; init; }

    [JsonPropertyName("followers")] public int Followers { get; init; }

    [JsonPropertyName("following")] public int Following { get; init; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; init; }
}