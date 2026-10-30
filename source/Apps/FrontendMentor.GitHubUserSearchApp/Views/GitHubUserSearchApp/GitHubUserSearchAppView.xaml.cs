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

using FrontendMentor.GitHubUserSearchApp.ViewModels.GitHubUserSearchApp;

namespace FrontendMentor.GitHubUserSearchApp.Views.GitHubUserSearchApp;

/// <inheritdoc cref="IGitHubUserSearchAppView" />
internal sealed partial class GitHubUserSearchAppView : IGitHubUserSearchAppView
{
    public GitHubUserSearchAppView(IGitHubUserSearchAppViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
        Loaded += async (_, _) => await viewModel.InitializeAsync();
    }
}