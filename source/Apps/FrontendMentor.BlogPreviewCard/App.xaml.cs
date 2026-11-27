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

using FrontendMentor.BlogPreviewCard.Controls.Windows;
using FrontendMentor.BlogPreviewCard.Factories.Blog;
using FrontendMentor.BlogPreviewCard.Factories.BlogAuthor;
using FrontendMentor.BlogPreviewCard.Services.Blogs;
using FrontendMentor.BlogPreviewCard.ViewModels.BlogPreviewCard;
using FrontendMentor.BlogPreviewCard.Views.BlogPreviewCard;
using FrontendMentor.Core.Windows;
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

        services.AddTransient<IBlogPreviewCardWindow, BlogPreviewCardWindow>()
            .AddTransient<IBlogPreviewCardView, BlogPreviewCardView>()
            .AddTransient<IBlogPreviewCardViewModel, BlogPreviewCardViewModel>()
            .AddSingleton<IBlogsService, BlogsService>()
            .AddSingleton<IBlogBindableModelFactory, BlogBindableModelFactory>()
            .AddSingleton<IBlogAuthorBindableModelFactory, BlogAuthorBindableModelFactory>();
    }

    /// <inheritdoc />
    protected override IWindow CreateMainWindow(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IBlogPreviewCardWindow>();
    }
}