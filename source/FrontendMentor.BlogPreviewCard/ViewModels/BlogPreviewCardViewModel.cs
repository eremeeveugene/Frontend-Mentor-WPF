// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.BlogPreviewCard.BindableModels;
using FrontendMentor.BlogPreviewCard.Services.Blogs;
using FrontendMentor.Core.ViewModels;

namespace FrontendMentor.BlogPreviewCard.ViewModels;

internal sealed class BlogPreviewCardViewModel(
    IContainerProvider containerProvider,
    IBlogsService blogsService)
    : NavigationViewModelBase
{
    private BlogBindableModel? _blog;

    public BlogBindableModel? Blog
    {
        get => _blog;
        private set => SetProperty(ref _blog, value);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        var blog = blogsService.GetBlog();

        Blog = BlogBindableModel.Create(containerProvider, new BlogBindableModel.Parameters(blog));
    }
}