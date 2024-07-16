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

using FrontendMentor.BlogPreviewCard.Constants;
using FrontendMentor.BlogPreviewCard.Controls.Windows;
using FrontendMentor.BlogPreviewCard.Services.Blogs;
using FrontendMentor.BlogPreviewCard.Views;
using Prism.Ioc;
using System.Windows;

namespace FrontendMentor.BlogPreviewCard;

internal sealed partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<BlogPreviewCardWindow>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigateToShellRegion(BlogPreviewCardViewNames.BlogPreviewCard);
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterSingleton<IBlogsService, BlogsService>();
        containerRegistry.RegisterForNavigation<BlogPreviewCardView>(BlogPreviewCardViewNames.BlogPreviewCard);
    }
}