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
using FrontendMentor.BlogPreviewCard.Models.BlogAuthors;
using FrontendMentor.Core.Services.BitmapImages;
using Microsoft.Extensions.Logging;

namespace FrontendMentor.BlogPreviewCard.Factories.BlogAuthor;

/// <inheritdoc />
internal sealed class BlogAuthorBindableModelFactory : IBlogAuthorBindableModelFactory
{
    private readonly IBitmapImagesService _bitmapImagesService;
    private readonly ILogger<BlogAuthorBindableModel> _logger;

    public BlogAuthorBindableModelFactory(
        IBitmapImagesService bitmapImagesService,
        ILogger<BlogAuthorBindableModel> logger)
    {
        _bitmapImagesService = bitmapImagesService;
        _logger = logger;
    }

    /// <inheritdoc />
    public IBlogAuthorBindableModel Create(BlogAuthorModel blogAuthor)
    {
        return new BlogAuthorBindableModel(_bitmapImagesService, _logger, blogAuthor);
    }
}