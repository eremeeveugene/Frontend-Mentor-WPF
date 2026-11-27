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
using FrontendMentor.Assets.Services.Themes;
using FrontendMentor.Core.Bindables;
using FrontendMentor.Core.Commands;
using FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;
using FrontendMentor.GitHubUserSearchApp.Factories.GitHubUser;
using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;
using FrontendMentor.GitHubUserSearchApp.Properties;
using FrontendMentor.GitHubUserSearchApp.Services.GitHubUsers;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Windows.Input;

namespace FrontendMentor.GitHubUserSearchApp.ViewModels.GitHubUserSearchApp;

/// <inheritdoc cref="IGitHubUserSearchAppViewModel" />
internal sealed class GitHubUserSearchAppViewModel : BindableBase, IGitHubUserSearchAppViewModel
{
    private const string DefaultUsername = "octocat";

    private readonly IGitHubUserBindableModelFactory _gitHubUserFactory;
    private readonly IGitHubUsersService _gitHubUsersService;
    private readonly ILogger<GitHubUserSearchAppViewModel> _logger;
    private readonly IThemeService _themeService;
    private CancellationTokenSource? _loadGitHubUserCancellationTokenSource;

    public GitHubUserSearchAppViewModel(
        IGitHubUsersService gitHubUsersService,
        IGitHubUserBindableModelFactory gitHubUserFactory,
        ILogger<GitHubUserSearchAppViewModel> logger,
        IThemeService themeService)
    {
        _gitHubUsersService = gitHubUsersService;
        _gitHubUserFactory = gitHubUserFactory;
        _logger = logger;
        _themeService = themeService;
    }

    /// <inheritdoc />
    public ICommand SearchUserCommand => field ??= new AsyncDelegateCommand(SearchUserAsync);

    /// <inheritdoc />
    public ICommand SwitchThemeCommand => field ??= new DelegateCommand(SwitchTheme);

    /// <inheritdoc />
    public string ThemeSwitchText => _themeService.CurrentTheme == Theme.Light
        ? Resources.GitHubUserSearchAppView_DarkThemeButton_Text
        : Resources.GitHubUserSearchAppView_LightThemeButton_Text;

    /// <inheritdoc />
    public string Username
    {
        get;
        set => SetProperty(ref field, value);
    } = string.Empty;

    /// <inheritdoc />
    public bool HasNoResults
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public IGitHubUserBindableModel? GitHubUser
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public Task LoadAsync(CancellationToken cancellationToken)
    {
        return LoadGitHubUserAsync(DefaultUsername, cancellationToken);
    }

    /// <summary>
    ///     Switches between the light and the dark theme.
    /// </summary>
    private void SwitchTheme()
    {
        _themeService.SetTheme(_themeService.CurrentTheme == Theme.Light ? Theme.Dark : Theme.Light);

        RaisePropertyChanged(nameof(ThemeSwitchText));
    }

    /// <summary>
    ///     Searches the GitHub user by <see cref="Username" />.
    /// </summary>
    /// <returns>A task that completes when the search is done.</returns>
    private Task SearchUserAsync()
    {
        return LoadGitHubUserAsync(Username);
    }

    /// <summary>
    ///     Loads a GitHub user and cancels the load that is still running, if any.
    /// </summary>
    /// <param name="username">The login of the user.</param>
    /// <param name="cancellationToken">The token of the caller that cancels the load.</param>
    /// <returns>
    ///     A task that completes when the user is loaded or replaced by a newer search, and that is canceled when
    ///     <paramref name="cancellationToken" /> cancels the load.
    /// </returns>
    private async Task LoadGitHubUserAsync(string username, CancellationToken cancellationToken = default)
    {
        username = username.Trim();

        if (username.Length == 0)
        {
            return;
        }

        CancelLoadGitHubUser();

        _loadGitHubUserCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        var loadCancellationToken = _loadGitHubUserCancellationTokenSource.Token;

        try
        {
            var gitHubUser = await _gitHubUsersService.GetUserAsync(username, loadCancellationToken);

            HasNoResults = gitHubUser == null;

            if (gitHubUser != null)
            {
                GitHubUser = _gitHubUserFactory.Create(gitHubUser);
            }
        }
        catch (OperationCanceledException) when (loadCancellationToken.IsCancellationRequested)
        {
            // A newer search replaced this one, which is not a failure. A cancellation of the caller is passed on.
            cancellationToken.ThrowIfCancellationRequested();
        }
        catch (Exception exception) when (exception is HttpRequestException or OperationCanceledException)
        {
            _logger.LogError(exception, "Failed to load the GitHub user '{Username}'.", username);

            HasNoResults = true;
        }
    }

    /// <summary>
    ///     Cancels the load of the GitHub user that is still running, if any.
    /// </summary>
    private void CancelLoadGitHubUser()
    {
        _loadGitHubUserCancellationTokenSource?.Cancel();
        _loadGitHubUserCancellationTokenSource?.Dispose();
        _loadGitHubUserCancellationTokenSource = null;
    }
}