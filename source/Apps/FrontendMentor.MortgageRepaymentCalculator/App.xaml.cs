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
using FrontendMentor.MortgageRepaymentCalculator.Controls.Windows;
using FrontendMentor.MortgageRepaymentCalculator.Factories.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Services.MortgageRepayments;
using FrontendMentor.MortgageRepaymentCalculator.Validators.MortgageForm;
using FrontendMentor.MortgageRepaymentCalculator.ViewModels.MortgageRepaymentCalculator;
using FrontendMentor.MortgageRepaymentCalculator.Views.MortgageRepaymentCalculator;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.MortgageRepaymentCalculator;

/// <summary>
///     The application entry point.
/// </summary>
internal sealed partial class App
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddTransient<IMortgageRepaymentCalculatorWindow, MortgageRepaymentCalculatorWindow>()
            .AddTransient<IMortgageRepaymentCalculatorView, MortgageRepaymentCalculatorView>()
            .AddTransient<IMortgageRepaymentCalculatorViewModel, MortgageRepaymentCalculatorViewModel>()
            .AddSingleton<IMortgageRepaymentsService, MortgageRepaymentsService>()
            .AddSingleton<IMortgageRepaymentBindableModelFactory, MortgageRepaymentBindableModelFactory>()
            .AddSingleton<IMortgageFormValidator, MortgageFormValidator>();
    }

    /// <inheritdoc />
    protected override IWindow CreateMainWindow(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IMortgageRepaymentCalculatorWindow>();
    }
}