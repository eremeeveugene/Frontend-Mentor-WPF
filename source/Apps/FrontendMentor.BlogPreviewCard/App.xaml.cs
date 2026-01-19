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

using DryIoc;
using FrontendMentor.BlogPreviewCard.BindableModels;
using FrontendMentor.BlogPreviewCard.Services;
using FrontendMentor.BlogPreviewCard.Services.Blogs;
using FrontendMentor.BlogPreviewCard.ViewModels;
using FrontendMentor.BlogPreviewCard.Views;
using FrontendMentor.Core.Extensions;
using System.Windows;

namespace FrontendMentor.BlogPreviewCard;

internal sealed partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var shell = Container.Resolve<BlogPreviewCardView>();

        shell.Show();
    }

    protected override void RegisterTypes(IContainer container)
    {
        base.RegisterTypes(container);

        container.RegisterSingleton<IBlogsService, BlogsService>();
        container.Register<BlogBindableModel>(Reuse.Transient);
        container.RegisterSingleton<IBlogBindableModelFactory, BlogBindableModelFactory>();
        container.RegisterViewWithViewModel<BlogPreviewCardView, BlogPreviewCardViewModel>();
    }
}