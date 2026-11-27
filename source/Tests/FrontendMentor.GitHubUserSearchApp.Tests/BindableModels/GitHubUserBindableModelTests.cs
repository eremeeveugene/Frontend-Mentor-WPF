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
using FrontendMentor.GitHubUserSearchApp.Tests.Fakes;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net.Http;

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

        var bindableModel = CreateBindableModel(user, new FakeBitmapImagesService());

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

        var bindableModel = CreateBindableModel(user, new FakeBitmapImagesService());

        Assert.AreEqual("ada", bindableModel.Name);
        Assert.IsNull(bindableModel.Bio);
    }

    [TestMethod]
    public void Constructor_LoadsTheAvatarAtItsDisplayWidth()
    {
        var bitmapImagesService = new FakeBitmapImagesService();
        var user = new GitHubUserModel { Login = "ada", AvatarUrl = "https://example.com/a.png" };

        var bindableModel = CreateBindableModel(user, bitmapImagesService);

        Assert.AreSame(FakeBitmapImagesService.Image, bindableModel.AvatarImage);
        CollectionAssert.AreEqual(
            new[] { (new Uri("https://example.com/a.png"), 117) },
            bitmapImagesService.UrlRequests);
    }

    [TestMethod]
    public void Constructor_AvatarCannotBeLoaded_LeavesTheAvatarEmpty()
    {
        var user = new GitHubUserModel { Login = "ada", AvatarUrl = "https://example.com/a.png" };

        foreach (var exception in new Exception[] { new HttpRequestException("offline"), new TaskCanceledException() })
        {
            var bindableModel = CreateBindableModel(user, new FakeBitmapImagesService { ExceptionToThrow = exception });

            Assert.IsNull(bindableModel.AvatarImage);
        }
    }

    [TestMethod]
    public void Constructor_BlankFields_AreTreatedAsMissing()
    {
        var user = new GitHubUserModel
        {
            Login = "ada",
            AvatarUrl = "https://example.com/a.png",
            Bio = "",
            Location = " ",
            Blog = "",
            TwitterUsername = "",
            Company = ""
        };

        var bindableModel = CreateBindableModel(user, new FakeBitmapImagesService());

        Assert.IsNull(bindableModel.Bio);
        Assert.IsNull(bindableModel.Location);
        Assert.IsNull(bindableModel.Blog);
        Assert.IsNull(bindableModel.TwitterUsername);
        Assert.IsNull(bindableModel.Company);
        Assert.IsFalse(bindableModel.OpenBlogCommand.CanExecute(null));
        Assert.IsFalse(bindableModel.OpenTwitterCommand.CanExecute(null));
        Assert.IsFalse(bindableModel.OpenCompanyCommand.CanExecute(null));
    }

    [TestMethod]
    public void OpenBlogCommand_OpensTheBlog()
    {
        var cases = new[]
        {
            ("https://github.blog", "https://github.blog/"),
            ("http://example.com/blog", "http://example.com/blog"),
            ("github.blog", "https://github.blog/")
        };

        foreach (var (blog, expectedLink) in cases)
        {
            var processesService = new FakeProcessesService();
            var bindableModel = CreateBindableModel(CreateUser(blog: blog), processesService);

            Assert.IsTrue(bindableModel.OpenBlogCommand.CanExecute(null), blog);

            bindableModel.OpenBlogCommand.Execute(null);

            CollectionAssert.AreEqual(new[] { expectedLink }, processesService.StartedFileNames, blog);
        }
    }

    [TestMethod]
    public void OpenBlogCommand_BlogIsNotAWebLink_CannotRun()
    {
        foreach (var blog in new[] { "file:///C:/Windows/notepad.exe", "ftp://example.com", "https://" })
        {
            var bindableModel = CreateBindableModel(CreateUser(blog: blog), new FakeProcessesService());

            Assert.IsFalse(bindableModel.OpenBlogCommand.CanExecute(null), blog);
        }
    }

    [TestMethod]
    public void OpenTwitterCommand_OpensTheProfile()
    {
        var processesService = new FakeProcessesService();
        var bindableModel = CreateBindableModel(CreateUser(twitterUsername: "github"), processesService);

        bindableModel.OpenTwitterCommand.Execute(null);

        CollectionAssert.AreEqual(new[] { "https://x.com/github" }, processesService.StartedFileNames);
    }

    [TestMethod]
    public void OpenCompanyCommand_Organization_OpensTheOrganization()
    {
        var processesService = new FakeProcessesService();
        var bindableModel = CreateBindableModel(CreateUser(company: "@frontend-mentor"), processesService);

        bindableModel.OpenCompanyCommand.Execute(null);

        CollectionAssert.AreEqual(new[] { "https://github.com/frontend-mentor" }, processesService.StartedFileNames);
    }

    [TestMethod]
    public void OpenCompanyCommand_CompanyIsNotAnOrganization_CannotRun()
    {
        foreach (var company in new[] { "GitHub", "@", "@github, Inc.", "@../settings" })
        {
            var bindableModel = CreateBindableModel(CreateUser(company: company), new FakeProcessesService());

            Assert.IsFalse(bindableModel.OpenCompanyCommand.CanExecute(null), company);
        }
    }

    private static GitHubUserModel CreateUser(string? blog = null, string? twitterUsername = null, string? company = null)
    {
        return new GitHubUserModel
        {
            Login = "ada",
            AvatarUrl = "https://example.com/a.png",
            Blog = blog,
            TwitterUsername = twitterUsername,
            Company = company
        };
    }

    private static GitHubUserBindableModel CreateBindableModel(
        GitHubUserModel user,
        FakeBitmapImagesService bitmapImagesService)
    {
        return new GitHubUserBindableModel(
            bitmapImagesService,
            new FakeProcessesService(),
            NullLogger<GitHubUserBindableModel>.Instance,
            user);
    }

    private static GitHubUserBindableModel CreateBindableModel(
        GitHubUserModel user,
        FakeProcessesService processesService)
    {
        return new GitHubUserBindableModel(
            new FakeBitmapImagesService(),
            processesService,
            NullLogger<GitHubUserBindableModel>.Instance,
            user);
    }
}