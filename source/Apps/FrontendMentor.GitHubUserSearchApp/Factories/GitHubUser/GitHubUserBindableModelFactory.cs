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

using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.Core.Services.Processes;
using FrontendMentor.GitHubUserSearchApp.BindableModels.GitHubUser;
using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;
using Microsoft.Extensions.Logging;

namespace FrontendMentor.GitHubUserSearchApp.Factories.GitHubUser;

/// <inheritdoc />
internal sealed class GitHubUserBindableModelFactory : IGitHubUserBindableModelFactory
{
    private readonly IBitmapImagesService _bitmapImagesService;
    private readonly ILogger<GitHubUserBindableModel> _logger;
    private readonly IProcessesService _processesService;

    public GitHubUserBindableModelFactory(
        IBitmapImagesService bitmapImagesService,
        IProcessesService processesService,
        ILogger<GitHubUserBindableModel> logger)
    {
        _bitmapImagesService = bitmapImagesService;
        _processesService = processesService;
        _logger = logger;
    }

    /// <inheritdoc />
    public IGitHubUserBindableModel Create(GitHubUserModel gitHubUser)
    {
        return new GitHubUserBindableModel(_bitmapImagesService, _processesService, _logger, gitHubUser);
    }
}