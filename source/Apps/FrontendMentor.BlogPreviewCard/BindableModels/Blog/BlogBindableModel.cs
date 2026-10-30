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

using FrontendMentor.BlogPreviewCard.BindableModels.BlogAuthor;
using FrontendMentor.Core.Bindables;
using FrontendMentor.Core.Extensions;
using FrontendMentor.Core.Services.BitmapImages;
using Microsoft.Extensions.Logging;
using System.Windows.Media.Imaging;

namespace FrontendMentor.BlogPreviewCard.BindableModels.Blog;

/// <inheritdoc cref="IBlogBindableModel" />
internal sealed class BlogBindableModel : BindableBase, IBlogBindableModel
{
    private readonly IBitmapImagesService _bitmapImagesService;
    private readonly ILogger<BlogBindableModel> _logger;

    public BlogBindableModel(
        IBitmapImagesService bitmapImagesService,
        Func<BlogAuthorBindableModelParameters, IBlogAuthorBindableModel> blogAuthorFactory,
        ILogger<BlogBindableModel> logger,
        BlogBindableModelParameters parameters)
    {
        _bitmapImagesService = bitmapImagesService;
        _logger = logger;

        var blog = parameters.Blog;

        Title = blog.Title;
        Description = blog.Description;
        Category = blog.Category;
        PublishedDate = blog.PublishedDate;
        BlogAuthor = blogAuthorFactory(new BlogAuthorBindableModelParameters(blog.BlogAuthor));

        LoadBlogImageAsync(blog.ImageBase64String).Observe(_logger, "Failed to load the cover image of the blog.");
    }

    /// <inheritdoc />
    public string Title { get; }

    /// <inheritdoc />
    public string Description { get; }

    /// <inheritdoc />
    public string Category { get; }

    /// <inheritdoc />
    public DateTime PublishedDate { get; }

    /// <inheritdoc />
    public BitmapImage? BlogImage
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public IBlogAuthorBindableModel BlogAuthor { get; }

    /// <summary>
    ///     Decodes the cover image of the blog on a background thread and sets it.
    /// </summary>
    /// <param name="imageBase64String">The Base64 encoded cover image.</param>
    /// <returns>A task that completes when the image is set.</returns>
    private async Task LoadBlogImageAsync(string imageBase64String)
    {
        BlogImage = await _bitmapImagesService.GetBitmapImageFromBase64StringAsync(imageBase64String);
    }
}