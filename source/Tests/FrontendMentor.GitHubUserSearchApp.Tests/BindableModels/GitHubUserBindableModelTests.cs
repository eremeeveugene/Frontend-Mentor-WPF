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

namespace FrontendMentor.GitHubUserSearchApp.Tests.BindableModels;

[TestClass]
public sealed class GitHubUserBindableModelTests
{
    [TestMethod]
    public void Constructor_MapsTheUser()
    {
        var user = new GitHubUserModel
        {
            Login = "octocat",
            Name = "The Octocat",
            AvatarUrl = "https://example.com/avatar.png",
            Bio = "A bio",
            Location = "San Francisco",
            Blog = "https://github.blog",
            TwitterUsername = "github",
            Company = "@github",
            PublicRepos = 8,
            Followers = 100,
            Following = 9,
            CreatedAt = new DateTime(2011, 1, 25)
        };

        var bindableModel = new GitHubUserBindableModel(new GitHubUserBindableModelParameters(user));

        Assert.AreEqual("octocat", bindableModel.Login);
        Assert.AreEqual("The Octocat", bindableModel.Name);
        Assert.AreEqual("A bio", bindableModel.Bio);
        Assert.AreEqual(8, bindableModel.Repos);
        Assert.AreEqual(100, bindableModel.Followers);
        Assert.AreEqual(9, bindableModel.Following);
        Assert.AreEqual(new DateTime(2011, 1, 25), bindableModel.DateJoined);
    }

    [TestMethod]
    public void Constructor_UserWithoutName_UsesTheLoginAsTheName()
    {
        var user = new GitHubUserModel { Login = "ada", AvatarUrl = "https://example.com/a.png" };

        var bindableModel = new GitHubUserBindableModel(new GitHubUserBindableModelParameters(user));

        Assert.AreEqual("ada", bindableModel.Name);
        Assert.IsNull(bindableModel.Bio);
    }
}