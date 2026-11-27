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

using FrontendMentor.Core.Windows;
using FrontendMentor.ResultsSummaryComponent.Controls.Windows;
using FrontendMentor.ResultsSummaryComponent.Factories.ResultSummary;
using FrontendMentor.ResultsSummaryComponent.Factories.SummaryItem;
using FrontendMentor.ResultsSummaryComponent.Services.ResultSummaries;
using FrontendMentor.ResultsSummaryComponent.ViewModels.ResultsSummaryComponent;
using FrontendMentor.ResultsSummaryComponent.Views.ResultsSummaryComponent;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.ResultsSummaryComponent;

/// <summary>
///     The application entry point.
/// </summary>
internal sealed partial class App
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddTransient<IResultsSummaryComponentWindow, ResultsSummaryComponentWindow>()
            .AddTransient<IResultsSummaryComponentView, ResultsSummaryComponentView>()
            .AddTransient<IResultsSummaryComponentViewModel, ResultsSummaryComponentViewModel>()
            .AddSingleton<IResultSummariesService, ResultSummariesService>()
            .AddSingleton<IResultSummaryBindableModelFactory, ResultSummaryBindableModelFactory>()
            .AddSingleton<ISummaryItemBindableModelFactory, SummaryItemBindableModelFactory>();
    }

    /// <inheritdoc />
    protected override IWindow CreateMainWindow(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IResultsSummaryComponentWindow>();
    }
}