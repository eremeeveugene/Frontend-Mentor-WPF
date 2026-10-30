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

using FrontendMentor.BlogPreviewCard.BindableModels.Blog;
using FrontendMentor.BlogPreviewCard.Models;
using FrontendMentor.BlogPreviewCard.Services.Blogs;
using FrontendMentor.Core.Bindables;

namespace FrontendMentor.BlogPreviewCard.ViewModels.BlogPreviewCard;

/// <inheritdoc cref="IBlogPreviewCardViewModel" />
internal sealed class BlogPreviewCardViewModel : BindableBase, IBlogPreviewCardViewModel
{
    public BlogPreviewCardViewModel(Func<BlogBindableModelParameters, IBlogBindableModel> blogFactory, IBlogsService blogsService)
    {
        Blog = blogFactory(new BlogBindableModelParameters(blogsService.GetBlog()));
    }

    /// <inheritdoc />
    public IBlogBindableModel Blog { get; }
}