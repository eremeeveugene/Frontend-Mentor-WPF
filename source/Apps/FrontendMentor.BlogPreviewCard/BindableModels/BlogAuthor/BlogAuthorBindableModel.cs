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

using FrontendMentor.Core.Bindables;
using FrontendMentor.Core.Extensions;
using FrontendMentor.Core.Services.BitmapImages;
using Microsoft.Extensions.Logging;
using System.Windows.Media.Imaging;

namespace FrontendMentor.BlogPreviewCard.BindableModels.BlogAuthor;

/// <inheritdoc cref="IBlogAuthorBindableModel" />
internal sealed class BlogAuthorBindableModel : BindableBase, IBlogAuthorBindableModel
{
    private readonly IBitmapImagesService _bitmapImagesService;
    private readonly ILogger<BlogAuthorBindableModel> _logger;

    public BlogAuthorBindableModel(
        IBitmapImagesService bitmapImagesService,
        ILogger<BlogAuthorBindableModel> logger,
        BlogAuthorBindableModelParameters parameters)
    {
        _bitmapImagesService = bitmapImagesService;
        _logger = logger;

        var blogAuthor = parameters.BlogAuthor;

        FirstName = blogAuthor.FirstName;
        LastName = blogAuthor.LastName;

        LoadUserImageAsync(blogAuthor.ImageBase64String).Observe(_logger, "Failed to load the photo of the blog author.");
    }

    /// <inheritdoc />
    public string FirstName { get; }

    /// <inheritdoc />
    public string LastName { get; }

    /// <inheritdoc />
    public BitmapImage? UserImage
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <summary>
    ///     Decodes the photo of the author on a background thread and sets it.
    /// </summary>
    /// <param name="imageBase64String">The Base64 encoded photo.</param>
    /// <returns>A task that completes when the photo is set.</returns>
    private async Task LoadUserImageAsync(string imageBase64String)
    {
        UserImage = await _bitmapImagesService.GetBitmapImageFromBase64StringAsync(imageBase64String);
    }
}