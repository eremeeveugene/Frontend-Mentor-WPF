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

using FrontendMentor.Core.Bindables;

namespace FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;

/// <inheritdoc cref="IGitHubUserBindableModel" />
internal sealed class GitHubUserBindableModel : BindableBase, IGitHubUserBindableModel
{
    public GitHubUserBindableModel(GitHubUserBindableModelParameters parameters)
    {
        var gitHubUser = parameters.GitHubUser;

        Login = gitHubUser.Login;
        Name = gitHubUser.Name ?? gitHubUser.Login;
        AvatarUrl = gitHubUser.AvatarUrl;
        Bio = gitHubUser.Bio;
        Location = gitHubUser.Location;
        Blog = gitHubUser.Blog;
        TwitterUsername = gitHubUser.TwitterUsername;
        Company = gitHubUser.Company;
        Repos = gitHubUser.PublicRepos;
        Followers = gitHubUser.Followers;
        Following = gitHubUser.Following;
        DateJoined = gitHubUser.CreatedAt;
    }

    /// <inheritdoc />
    public string Login { get; }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public string AvatarUrl { get; }

    /// <inheritdoc />
    public string? Bio { get; }

    /// <inheritdoc />
    public string? Location { get; }

    /// <inheritdoc />
    public string? Blog { get; }

    /// <inheritdoc />
    public string? TwitterUsername { get; }

    /// <inheritdoc />
    public string? Company { get; }

    /// <inheritdoc />
    public int Repos { get; }

    /// <inheritdoc />
    public int Followers { get; }

    /// <inheritdoc />
    public int Following { get; }

    /// <inheritdoc />
    public DateTime DateJoined { get; }
}