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
using FrontendMentor.Core.Commands;
using FrontendMentor.Core.Extensions;
using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.Core.Services.Processes;
using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;
using Microsoft.Extensions.Logging;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;

/// <inheritdoc cref="IGitHubUserBindableModel" />
internal sealed class GitHubUserBindableModel : BindableBase, IGitHubUserBindableModel
{
    /// <summary>
    ///     The width of the avatar in the view, so that no larger image is kept in memory.
    /// </summary>
    private const int AvatarDecodePixelWidth = 117;

    private const string GitHubUrl = "https://github.com/";
    private const string TwitterUrl = "https://x.com/";

    private readonly IBitmapImagesService _bitmapImagesService;
    private readonly Uri? _blogUri;
    private readonly Uri? _companyUri;
    private readonly ILogger<GitHubUserBindableModel> _logger;
    private readonly IProcessesService _processesService;
    private readonly Uri? _twitterUri;

    public GitHubUserBindableModel(
        IBitmapImagesService bitmapImagesService,
        IProcessesService processesService,
        ILogger<GitHubUserBindableModel> logger,
        GitHubUserModel gitHubUser)
    {
        _bitmapImagesService = bitmapImagesService;
        _processesService = processesService;
        _logger = logger;

        Login = gitHubUser.Login;
        Name = gitHubUser.Name ?? gitHubUser.Login;
        Bio = NullIfWhiteSpace(gitHubUser.Bio);
        Location = NullIfWhiteSpace(gitHubUser.Location);
        Blog = NullIfWhiteSpace(gitHubUser.Blog);
        TwitterUsername = NullIfWhiteSpace(gitHubUser.TwitterUsername);
        Company = NullIfWhiteSpace(gitHubUser.Company);
        Repos = gitHubUser.PublicRepos;
        Followers = gitHubUser.Followers;
        Following = gitHubUser.Following;
        DateJoined = gitHubUser.CreatedAt;

        _blogUri = CreateBlogUri(Blog);
        _twitterUri = TwitterUsername == null ? null : new Uri(TwitterUrl + Uri.EscapeDataString(TwitterUsername));
        _companyUri = CreateCompanyUri(Company);

        LoadAvatarImageAsync(gitHubUser.AvatarUrl).Observe(_logger, "Failed to load the avatar of the GitHub user.");
    }

    /// <inheritdoc />
    public ICommand OpenBlogCommand => field ??= new DelegateCommand(() => OpenLink(_blogUri), () => _blogUri != null);

    /// <inheritdoc />
    public ICommand OpenTwitterCommand => field ??= new DelegateCommand(() => OpenLink(_twitterUri), () => _twitterUri != null);

    /// <inheritdoc />
    public ICommand OpenCompanyCommand => field ??= new DelegateCommand(() => OpenLink(_companyUri), () => _companyUri != null);

    /// <inheritdoc />
    public string Login { get; }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public BitmapImage? AvatarImage
    {
        get;
        private set => SetProperty(ref field, value);
    }

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

    /// <summary>
    ///     Loads the avatar on a background thread and sets it.
    /// </summary>
    /// <param name="avatarUrl">The URL of the avatar.</param>
    /// <returns>A task that completes when the avatar is set.</returns>
    private async Task LoadAvatarImageAsync(string avatarUrl)
    {
        try
        {
            AvatarImage = await _bitmapImagesService.GetBitmapImageFromUrlAsync(new Uri(avatarUrl), AvatarDecodePixelWidth);
        }
        catch (OperationCanceledException exception)
        {
            // A download that times out ends as a canceled task, which is not observed as a failure.
            _logger.LogError(exception, "The download of the avatar of the GitHub user timed out.");
        }
    }

    /// <summary>
    ///     Opens a link with the shell.
    /// </summary>
    /// <param name="uri">The link to open, or <c>null</c> to do nothing.</param>
    private void OpenLink(Uri? uri)
    {
        if (uri != null)
        {
            _processesService.StartProcess(uri.AbsoluteUri);
        }
    }

    /// <summary>
    ///     Returns <c>null</c> for a missing or blank text, which the GitHub API returns as an empty string for some fields.
    /// </summary>
    /// <param name="value">The text.</param>
    /// <returns>The text, or <c>null</c> when it is blank.</returns>
    private static string? NullIfWhiteSpace(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value;
    }

    /// <summary>
    ///     Creates the link of a blog, which the user may enter without a scheme.
    /// </summary>
    /// <param name="blog">The blog, if any.</param>
    /// <returns>The web link of the blog, or <c>null</c> when it is not a web link.</returns>
    private static Uri? CreateBlogUri(string? blog)
    {
        if (blog == null)
        {
            return null;
        }

        if (!blog.Contains("://", StringComparison.Ordinal))
        {
            blog = "https://" + blog;
        }

        // Only web links are opened, so that the shell never starts a program or a file from the user data.
        return Uri.TryCreate(blog, UriKind.Absolute, out var uri) &&
               (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp)
            ? uri
            : null;
    }

    /// <summary>
    ///     Creates the link of a company that is given as a GitHub organization, such as <c>@github</c>.
    /// </summary>
    /// <param name="company">The company, if any.</param>
    /// <returns>The link of the organization, or <c>null</c> when the company is not an organization.</returns>
    private static Uri? CreateCompanyUri(string? company)
    {
        if (company is not { Length: > 1 } || company[0] != '@')
        {
            return null;
        }

        var organization = company.AsSpan(1);

        foreach (var character in organization)
        {
            if (!char.IsAsciiLetterOrDigit(character) && character != '-')
            {
                return null;
            }
        }

        return new Uri(string.Concat(GitHubUrl, organization));
    }
}