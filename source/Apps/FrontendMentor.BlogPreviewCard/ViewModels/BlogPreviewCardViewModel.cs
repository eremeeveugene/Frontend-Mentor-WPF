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

using FrontendMentor.BlogPreviewCard.BindableModels;
using FrontendMentor.BlogPreviewCard.Services;
using FrontendMentor.BlogPreviewCard.Services.Blogs;
using FrontendMentor.Core;

namespace FrontendMentor.BlogPreviewCard.ViewModels;

internal sealed class BlogPreviewCardViewModel : BindableBase
{
    private readonly IBlogsService _blogsService;
    private readonly IBlogBindableModelFactory _blogBindableModelFactory;

    public BlogPreviewCardViewModel(IBlogsService blogsService,
        IBlogBindableModelFactory blogBindableModelFactory)
    {
        _blogsService = blogsService;
        _blogBindableModelFactory = blogBindableModelFactory;

        Load();
    }

    public BlogBindableModel Blog
    {
        get;
        private set => SetProperty(ref field, value);
    } = null!;

    public void Load()
    {
        var blog = _blogsService.GetBlog();

        Blog = _blogBindableModelFactory.Create(new BlogBindableModel.Parameters(blog));
    }
}