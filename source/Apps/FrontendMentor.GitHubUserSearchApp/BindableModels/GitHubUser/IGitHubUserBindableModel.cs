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

using FrontendMentor.Core.BindableModels;

namespace FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;

/// <summary>
///     The presentation model of a GitHub user.
/// </summary>
internal interface IGitHubUserBindableModel : IBindableModel
{
    /// <summary>
    ///     Gets the login of the user.
    /// </summary>
    string Login { get; }

    /// <summary>
    ///     Gets the display name of the user, or the login when the user has no name.
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     Gets the URL of the avatar of the user.
    /// </summary>
    string AvatarUrl { get; }

    /// <summary>
    ///     Gets the biography of the user, if any.
    /// </summary>
    string? Bio { get; }

    /// <summary>
    ///     Gets the location of the user, if any.
    /// </summary>
    string? Location { get; }

    /// <summary>
    ///     Gets the blog of the user, if any.
    /// </summary>
    string? Blog { get; }

    /// <summary>
    ///     Gets the Twitter username of the user, if any.
    /// </summary>
    string? TwitterUsername { get; }

    /// <summary>
    ///     Gets the company of the user, if any.
    /// </summary>
    string? Company { get; }

    /// <summary>
    ///     Gets the number of public repositories of the user.
    /// </summary>
    int Repos { get; }

    /// <summary>
    ///     Gets the number of followers of the user.
    /// </summary>
    int Followers { get; }

    /// <summary>
    ///     Gets the number of users that the user follows.
    /// </summary>
    int Following { get; }

    /// <summary>
    ///     Gets the date when the user joined GitHub.
    /// </summary>
    DateTime DateJoined { get; }
}