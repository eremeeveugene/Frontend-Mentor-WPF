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
    private readonly IBlogBindableModelFactory _blogBindableModelFactory;
    private readonly IBlogsService _blogsService;

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

    private async void Load()
    {
        var blog = await _blogsService.GetBlogAsync();

        Blog = _blogBindableModelFactory.Create(new BlogBindableModel.Parameters(blog));
    }
}