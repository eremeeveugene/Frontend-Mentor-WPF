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

using FrontendMentor.Assets.Enums;
using FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;
using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;
using FrontendMentor.GitHubUserSearchApp.Properties;
using FrontendMentor.GitHubUserSearchApp.Tests.Fakes;
using FrontendMentor.GitHubUserSearchApp.ViewModels.GitHubUserSearchApp;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net.Http;

namespace FrontendMentor.GitHubUserSearchApp.Tests.ViewModels;

[TestClass]
public sealed class GitHubUserSearchAppViewModelTests
{
    private FakeGitHubUsersService _gitHubUsersService = null!;
    private FakeThemeService _themeService = null!;
    private GitHubUserSearchAppViewModel _viewModel = null!;

    [TestInitialize]
    public void Initialize()
    {
        _gitHubUsersService = new FakeGitHubUsersService();
        _themeService = new FakeThemeService();

        _gitHubUsersService.AddUser(CreateUser("octocat", "The Octocat"));
        _gitHubUsersService.AddUser(CreateUser("ada", null));

        _viewModel = new GitHubUserSearchAppViewModel(
            _gitHubUsersService,
            parameters => new GitHubUserBindableModel(parameters),
            NullLogger<GitHubUserSearchAppViewModel>.Instance,
            _themeService);
    }

    [TestMethod]
    public async Task InitializeAsync_LoadsTheDefaultUser()
    {
        await _viewModel.InitializeAsync();

        CollectionAssert.AreEqual(new[] { "octocat" }, _gitHubUsersService.RequestedUsernames);
        Assert.IsNotNull(_viewModel.GitHubUser);
        Assert.AreEqual("The Octocat", _viewModel.GitHubUser.Name);
        Assert.IsFalse(_viewModel.HasNoResults);
    }

    [TestMethod]
    public async Task SearchUserCommand_ExistingUser_ShowsTheUser()
    {
        _viewModel.Username = "  ada  ";

        _viewModel.SearchUserCommand.Execute(null);

        await WaitUntilAsync(() => _viewModel.GitHubUser != null);

        CollectionAssert.AreEqual(new[] { "ada" }, _gitHubUsersService.RequestedUsernames);
        Assert.AreEqual("ada", _viewModel.GitHubUser!.Name, "The name falls back to the login.");
        Assert.IsFalse(_viewModel.HasNoResults);
    }

    [TestMethod]
    public async Task SearchUserCommand_UnknownUser_ShowsNoResults_AndKeepsThePreviousUser()
    {
        await _viewModel.InitializeAsync();

        _viewModel.Username = "nobody";

        _viewModel.SearchUserCommand.Execute(null);

        await WaitUntilAsync(() => _viewModel.HasNoResults);

        Assert.AreEqual("The Octocat", _viewModel.GitHubUser!.Name);
    }

    [TestMethod]
    public void SearchUserCommand_EmptyUsername_DoesNotCallTheService()
    {
        _viewModel.Username = "   ";

        _viewModel.SearchUserCommand.Execute(null);

        Assert.AreEqual(0, _gitHubUsersService.RequestedUsernames.Count);
    }

    [TestMethod]
    public async Task InitializeAsync_RequestFails_ShowsNoResults()
    {
        _gitHubUsersService.ExceptionToThrow = new HttpRequestException("offline");

        await _viewModel.InitializeAsync();

        Assert.IsTrue(_viewModel.HasNoResults);
        Assert.IsNull(_viewModel.GitHubUser);
    }

    [TestMethod]
    public void SwitchThemeCommand_SwitchesTheThemeAndTheButtonText()
    {
        Assert.AreEqual(Resources.GitHubUserSearchAppView_DarkThemeButton_Text, _viewModel.ThemeSwitchText);

        var changedProperties = new List<string?>();

        _viewModel.PropertyChanged += (_, args) => changedProperties.Add(args.PropertyName);

        _viewModel.SwitchThemeCommand.Execute(null);

        Assert.AreEqual(Theme.Dark, _themeService.CurrentTheme);
        Assert.AreEqual(Resources.GitHubUserSearchAppView_LightThemeButton_Text, _viewModel.ThemeSwitchText);
        CollectionAssert.Contains(changedProperties, nameof(_viewModel.ThemeSwitchText));
    }

    private static GitHubUserModel CreateUser(string login, string? name)
    {
        return new GitHubUserModel
        {
            Login = login,
            Name = name,
            AvatarUrl = "https://example.com/avatar.png",
            CreatedAt = new DateTime(2011, 1, 25)
        };
    }

    private static async Task WaitUntilAsync(Func<bool> condition)
    {
        for (var i = 0; i < 200 && !condition(); i++)
        {
            await Task.Delay(10);
        }

        Assert.IsTrue(condition(), "The condition was not met in time.");
    }
}