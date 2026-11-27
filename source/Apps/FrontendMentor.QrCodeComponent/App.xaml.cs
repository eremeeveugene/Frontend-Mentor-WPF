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
using FrontendMentor.QrCodeComponent.Controls.Windows;
using FrontendMentor.QrCodeComponent.Factories.QrCode;
using FrontendMentor.QrCodeComponent.Services.QrCodes;
using FrontendMentor.QrCodeComponent.ViewModels.QrCodeComponent;
using FrontendMentor.QrCodeComponent.Views.QrCodeComponent;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.QrCodeComponent;

/// <summary>
///     The application entry point.
/// </summary>
internal sealed partial class App
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddTransient<IQrCodeComponentWindow, QrCodeComponentWindow>()
            .AddTransient<IQrCodeComponentView, QrCodeComponentView>()
            .AddTransient<IQrCodeComponentViewModel, QrCodeComponentViewModel>()
            .AddSingleton<IQrCodesService, QrCodesService>()
            .AddSingleton<IQrCodeBindableModelFactory, QrCodeBindableModelFactory>();
    }

    /// <inheritdoc />
    protected override IWindow CreateMainWindow(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IQrCodeComponentWindow>();
    }
}