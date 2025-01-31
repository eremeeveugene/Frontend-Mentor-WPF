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

using FrontendMentor.GitHubUserSearchApp.Models;
using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;

namespace FrontendMentor.GitHubUserSearchApp.BindableModels;

internal sealed class GitHubUserBindableModel(GitHubUserBindableModel.Parameters parameters) : BindableBase
{
    public string Login { get; } = parameters.GitHubUserModel.Login;
    public string Name { get; } = parameters.GitHubUserModel.Name;

    public static GitHubUserBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<GitHubUserBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(GitHubUserModel GitHubUserModel);
}