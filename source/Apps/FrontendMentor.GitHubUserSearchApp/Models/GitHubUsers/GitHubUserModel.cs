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

using Newtonsoft.Json;

namespace FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;

internal class GitHubUserModel
{
    [JsonProperty("login")] public string Login { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("avatar_url")] public string AvatarUrl { get; set; }

    [JsonProperty("public_repos")] public int PublicRepos { get; set; }

    [JsonProperty("followers")] public int Followers { get; set; }

    [JsonProperty("following")] public int Following { get; set; }
}