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

using FrontendMentor.Core.Windows;
using FrontendMentor.GitHubUserSearchApp.Controls.Windows;
using FrontendMentor.GitHubUserSearchApp.Factories.GitHubUser;
using FrontendMentor.GitHubUserSearchApp.Models.GitHubUsers;
using FrontendMentor.GitHubUserSearchApp.Services.GitHubUsers;
using FrontendMentor.GitHubUserSearchApp.ViewModels.GitHubUserSearchApp;
using FrontendMentor.GitHubUserSearchApp.Views.GitHubUserSearchApp;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.GitHubUserSearchApp;

/// <summary>
///     The application entry point.
/// </summary>
internal sealed partial class App
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddTransient<IGitHubUserSearchAppWindow, GitHubUserSearchAppWindow>()
            .AddTransient<IGitHubUserSearchAppView, GitHubUserSearchAppView>()
            .AddTransient<IGitHubUserSearchAppViewModel, GitHubUserSearchAppViewModel>()
            .AddHttpClient<IGitHubUsersService, GitHubUsersService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.github.com/");
                httpClient.Timeout = TimeSpan.FromSeconds(15);
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("FrontendMentorGitHubUserSearchApp");
                httpClient.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github+json");
            });

        services.AddSingleton<IGitHubUserBindableModelFactory, GitHubUserBindableModelFactory>();
    }

    /// <inheritdoc />
    protected override IWindow CreateMainWindow(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IGitHubUserSearchAppWindow>();
    }
}