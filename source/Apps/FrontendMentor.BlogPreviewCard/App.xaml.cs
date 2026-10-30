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
using FrontendMentor.BlogPreviewCard.BindableModels.BlogAuthor;
using FrontendMentor.BlogPreviewCard.Controls.Windows;
using FrontendMentor.BlogPreviewCard.Services.Blogs;
using FrontendMentor.BlogPreviewCard.ViewModels.BlogPreviewCard;
using FrontendMentor.BlogPreviewCard.Views.BlogPreviewCard;
using FrontendMentor.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.BlogPreviewCard;

/// <summary>
///     The application entry point.
/// </summary>
internal sealed partial class App
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddSingleton<IBlogsService, BlogsService>()
            .AddFactory<BlogBindableModelParameters, IBlogBindableModel, BlogBindableModel>()
            .AddFactory<BlogAuthorBindableModelParameters, IBlogAuthorBindableModel, BlogAuthorBindableModel>()
            .AddTransient<IBlogPreviewCardViewModel, BlogPreviewCardViewModel>()
            .AddMainWindow<IBlogPreviewCardWindow, BlogPreviewCardWindow>()
            .AddTransient<IBlogPreviewCardView, BlogPreviewCardView>();
    }
}