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

namespace FrontendMentor.GitHubUserSearchApp.BindableModels;

internal sealed class GitHubUserBindableModel(GitHubUserBindableModel.Parameters parameters) : BindableBase
{
    public string Login { get; } = parameters.GitHubUserModel.Login;
    public string Name { get; } = parameters.GitHubUserModel.Name;
    public string? Bio { get; } = parameters.GitHubUserModel.Bio;
    public string? Location { get; } = parameters.GitHubUserModel.Location;
    public string? Blog { get; } = parameters.GitHubUserModel.Blog;
    public string? TwitterUsername { get; } = parameters.GitHubUserModel.TwitterUsername;
    public string? Company { get; } = parameters.GitHubUserModel.Company;
    public int Repos { get; } = parameters.GitHubUserModel.PublicRepos;
    public int Followers { get; } = parameters.GitHubUserModel.Followers;
    public int Following { get; } = parameters.GitHubUserModel.Following;
    public DateTime DateJoined { get; } = parameters.GitHubUserModel.CreatedAt;

    public static GitHubUserBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<GitHubUserBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(GitHubUserModel GitHubUserModel);
}