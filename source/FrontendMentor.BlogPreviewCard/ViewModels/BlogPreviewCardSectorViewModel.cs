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
using Prism.Ioc;

namespace FrontendMentor.BlogPreviewCard.ViewModels;

internal sealed class BlogPreviewCardSectorViewModel(IContainerProvider containerProvider, IBlogsService blogsService)
    : ViewModelBase
{
    private BlogBindableModel? _blogBindableModel;

    public BlogBindableModel? BlogBindableModel
    {
        get => _blogBindableModel;
        private set => SetProperty(ref _blogBindableModel, value);
    }

    protected override Task LoadedOnceAsync()
    {
        var blogModel = blogsService.GetBlog();

        BlogBindableModel = BlogBindableModel.Create(containerProvider, blogModel);

        return base.LoadedOnceAsync();
    }
}