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
using FrontendMentor.OrderSummaryComponent.Controls.Windows;
using FrontendMentor.OrderSummaryComponent.Factories.OrderSummary;
using FrontendMentor.OrderSummaryComponent.Services.AnnualPlans;
using FrontendMentor.OrderSummaryComponent.ViewModels.OrderSummary;
using FrontendMentor.OrderSummaryComponent.Views.OrderSummary;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.OrderSummaryComponent;

/// <summary>
///     The application entry point.
/// </summary>
internal sealed partial class App
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddTransient<IOrderSummaryComponentWindow, OrderSummaryComponentWindow>()
            .AddTransient<IOrderSummaryView, OrderSummaryView>()
            .AddTransient<IOrderSummaryViewModel, OrderSummaryViewModel>()
            .AddSingleton<IAnnualPlansService, AnnualPlansService>()
            .AddSingleton<IOrderSummaryBindableModelFactory, OrderSummaryBindableModelFactory>();
    }

    /// <inheritdoc />
    protected override IWindow CreateMainWindow(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IOrderSummaryComponentWindow>();
    }
}