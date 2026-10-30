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

using FrontendMentor.Core.Extensions;
using FrontendMentor.OrderSummaryComponent.BindableModels.OrderSummary;
using FrontendMentor.OrderSummaryComponent.Controls.Windows;
using FrontendMentor.OrderSummaryComponent.Services.AnnualPlan;
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

        services.AddSingleton<IAnnualPlanService, AnnualPlanService>()
            .AddFactory<OrderSummaryBindableModelParameters, IOrderSummaryBindableModel, OrderSummaryBindableModel>()
            .AddTransient<IOrderSummaryViewModel, OrderSummaryViewModel>()
            .AddMainWindow<IOrderSummaryComponentWindow, OrderSummaryComponentWindow>()
            .AddTransient<IOrderSummaryView, OrderSummaryView>();
    }
}