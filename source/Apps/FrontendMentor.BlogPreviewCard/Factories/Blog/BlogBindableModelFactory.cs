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

using FrontendMentor.BlogPreviewCard.BindableModels.Blog;
using FrontendMentor.BlogPreviewCard.Factories.BlogAuthor;
using FrontendMentor.BlogPreviewCard.Models.Blogs;
using FrontendMentor.Core.Services.BitmapImages;
using Microsoft.Extensions.Logging;

namespace FrontendMentor.BlogPreviewCard.Factories.Blog;

/// <inheritdoc />
internal sealed class BlogBindableModelFactory : IBlogBindableModelFactory
{
    private readonly IBitmapImagesService _bitmapImagesService;
    private readonly IBlogAuthorBindableModelFactory _blogAuthorFactory;
    private readonly ILogger<BlogBindableModel> _logger;

    public BlogBindableModelFactory(
        IBitmapImagesService bitmapImagesService,
        IBlogAuthorBindableModelFactory blogAuthorFactory,
        ILogger<BlogBindableModel> logger)
    {
        _bitmapImagesService = bitmapImagesService;
        _blogAuthorFactory = blogAuthorFactory;
        _logger = logger;
    }

    /// <inheritdoc />
    public IBlogBindableModel Create(BlogModel blog)
    {
        return new BlogBindableModel(_bitmapImagesService, _blogAuthorFactory, _logger, blog);
    }
}