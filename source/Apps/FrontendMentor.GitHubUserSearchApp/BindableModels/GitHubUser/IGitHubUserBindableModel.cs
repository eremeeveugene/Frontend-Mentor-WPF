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
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
    ///     Gets the avatar of the user, or <c>null</c> until it is loaded.
    /// </summary>
    BitmapImage? AvatarImage { get; }

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
    ///     Gets the command that opens the blog, which can run when the blog is a web link.
    /// </summary>
    ICommand OpenBlogCommand { get; }

    /// <summary>
    ///     Gets the command that opens the Twitter profile, which can run when the user has a Twitter username.
    /// </summary>
    ICommand OpenTwitterCommand { get; }

    /// <summary>
    ///     Gets the command that opens the company, which can run when it is a GitHub organization, such as <c>@github</c>.
    /// </summary>
    ICommand OpenCompanyCommand { get; }

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