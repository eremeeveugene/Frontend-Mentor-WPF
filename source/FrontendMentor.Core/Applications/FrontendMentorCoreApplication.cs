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

using FrontendMentor.Core.Registrations;
using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.Core.Services.Cache;
using FrontendMentor.Core.Services.Processes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace FrontendMentor.Core.Applications;

/// <summary>
///     The base application that owns the service provider and shows the shell window.
/// </summary>
public abstract class FrontendMentorCoreApplication : Application
{
    private ServiceProvider? _serviceProvider;

    /// <summary>
    ///     Gets the service provider of the application.
    /// </summary>
    protected IServiceProvider ServiceProvider => _serviceProvider ?? throw new InvalidOperationException("The service provider is not initialized.");

    /// <summary>
    ///     Registers the services of the application.
    /// </summary>
    /// <param name="services">The service collection.</param>
    protected virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(loggingBuilder => loggingBuilder.AddDebug())
            .AddMemoryCache()
            .AddSingleton<ICacheService, CacheService>()
            .AddSingleton<IProcessesService, ProcessesService>()
            .AddSingleton<IBitmapImagesService, BitmapImagesService>();
    }

    /// <summary>
    ///     Called when the services are built and the shell window is created, before the shell window is shown.
    /// </summary>
    protected virtual void OnInitialized()
    {
    }

    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _serviceProvider = CreateServiceProvider();

        MainWindow = CreateShell();

        OnInitialized();

        MainWindow.Show();
    }

    /// <inheritdoc />
    protected override void OnExit(ExitEventArgs e)
    {
        _serviceProvider?.Dispose();

        base.OnExit(e);
    }

    /// <summary>
    ///     Creates the service provider from the services that <see cref="ConfigureServices" /> registers.
    /// </summary>
    /// <returns>The service provider.</returns>
    private ServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        return services.BuildServiceProvider();
    }

    /// <summary>
    ///     Creates the shell window of the application from the window that was registered with
    ///     <see cref="Extensions.ServiceCollectionExtensions.AddMainWindow{TWindow,TImplementation}" />.
    /// </summary>
    /// <returns>The shell window.</returns>
    private Window CreateShell()
    {
        var mainWindowRegistration = ServiceProvider.GetService<MainWindowRegistration>() ??
                                     throw new InvalidOperationException("The main window is not registered.");

        return ServiceProvider.GetRequiredService(mainWindowRegistration.ServiceType) as Window ??
               throw new InvalidOperationException(
                   $"'{mainWindowRegistration.ServiceType}' is not implemented by a window.");
    }
}