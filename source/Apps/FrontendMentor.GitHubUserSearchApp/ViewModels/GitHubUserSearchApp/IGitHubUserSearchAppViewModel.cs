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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;
using System.Windows.Input;

namespace FrontendMentor.GitHubUserSearchApp.ViewModels.GitHubUserSearchApp;

/// <summary>
///     The view model of the GitHub user search.
/// </summary>
internal interface IGitHubUserSearchAppViewModel : IViewModel
{
    /// <summary>
    ///     Gets the command that searches the GitHub user by <see cref="Username" />.
    /// </summary>
    ICommand SearchUserCommand { get; }

    /// <summary>
    ///     Gets the command that switches between the light and the dark theme.
    /// </summary>
    ICommand SwitchThemeCommand { get; }

    /// <summary>
    ///     Gets the text of the theme switch, which names the theme that it switches to.
    /// </summary>
    string ThemeSwitchText { get; }

    /// <summary>
    ///     Gets or sets the username to search for.
    /// </summary>
    string Username { get; set; }

    /// <summary>
    ///     Gets a value indicating whether the last search found no user.
    /// </summary>
    bool HasNoResults { get; }

    /// <summary>
    ///     Gets the GitHub user that is shown, if any.
    /// </summary>
    IGitHubUserBindableModel? GitHubUser { get; }

    /// <summary>
    ///     Loads the default GitHub user.
    /// </summary>
    /// <returns>A task that completes when the user is loaded.</returns>
    Task InitializeAsync();
}