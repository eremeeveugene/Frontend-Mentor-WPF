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

using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.Core.Services.Cache;
using FrontendMentor.Core.Services.Messages;
using FrontendMentor.Core.Services.Processes;
using FrontendMentor.Core.Services.UnhandledExceptions;
using FrontendMentor.Core.Services.ViewModelLoading;
using FrontendMentor.Core.Views;
using FrontendMentor.Core.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Threading;

namespace FrontendMentor.Core.Applications;

/// <summary>
///     The base application that owns the service provider and shows the main window.
/// </summary>
public abstract class FrontendMentorCoreApplication : Application
{
    private bool _isStarted;
    private ServiceProvider? _serviceProvider;
    private IUnhandledExceptionsService? _unhandledExceptionsService;

    /// <summary>
    ///     Gets the service provider of the application.
    /// </summary>
    protected IServiceProvider ServiceProvider => _serviceProvider ?? throw new InvalidOperationException("The service provider is not initialized.");

    /// <summary>
    ///     Creates the main window of the application. The application shows it when it starts.
    /// </summary>
    /// <param name="serviceProvider">The service provider of the application.</param>
    /// <returns>The main window.</returns>
    protected abstract IWindow CreateMainWindow(IServiceProvider serviceProvider);

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
            .AddSingleton<IBitmapImagesService, BitmapImagesService>()
            .AddSingleton<IMessagesService, MessagesService>()
            .AddSingleton<IUnhandledExceptionsService, UnhandledExceptionsService>()
            .AddSingleton<IViewModelLoadingService, ViewModelLoadingService>()
            .AddSingleton<ViewLoadingHandler>();

        services.AddHttpClient(BitmapImagesService.HttpClientName,
            httpClient => httpClient.Timeout = TimeSpan.FromSeconds(15));
    }

    /// <summary>
    ///     Called when the services are built and the main window is created, before the main window is shown.
    /// </summary>
    protected virtual void OnInitialized()
    {
    }

    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _serviceProvider = CreateServiceProvider();

        SubscribeToUnhandledExceptions();

        ServiceProvider.GetRequiredService<ViewLoadingHandler>().RegisterForAllViews();

        var mainWindow = CreateMainWindow(ServiceProvider);

        OnInitialized();

        mainWindow.Show();

        _isStarted = true;
    }

    /// <inheritdoc />
    protected override void OnExit(ExitEventArgs e)
    {
        UnsubscribeFromUnhandledExceptions();

        _serviceProvider?.Dispose();

        base.OnExit(e);
    }

    /// <summary>
    ///     Starts to handle the exceptions that nothing else handles.
    /// </summary>
    private void SubscribeToUnhandledExceptions()
    {
        _unhandledExceptionsService = ServiceProvider.GetRequiredService<IUnhandledExceptionsService>();

        DispatcherUnhandledException += OnDispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
    }

    /// <summary>
    ///     Stops to handle the exceptions that nothing else handles.
    /// </summary>
    private void UnsubscribeFromUnhandledExceptions()
    {
        DispatcherUnhandledException -= OnDispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException -= OnAppDomainUnhandledException;
        TaskScheduler.UnobservedTaskException -= OnUnobservedTaskException;
    }

    /// <summary>
    ///     Handles an exception of the UI thread. The application keeps running, unless it failed to start.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The data of the event.</param>
    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        _unhandledExceptionsService?.HandleUserInterfaceException(e.Exception);

        e.Handled = true;

        if (!_isStarted)
        {
            // Without this the process would keep running without a window.
            Shutdown(1);
        }
    }

    /// <summary>
    ///     Logs an exception of a background thread. The process ends afterwards.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The data of the event.</param>
    private void OnAppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception exception)
        {
            _unhandledExceptionsService?.LogBackgroundException(exception);
        }
    }

    /// <summary>
    ///     Logs the exception of a task that failed without being observed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The data of the event.</param>
    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        _unhandledExceptionsService?.LogBackgroundException(e.Exception);

        e.SetObserved();
    }

    /// <summary>
    ///     Creates the service provider from the services that <see cref="ConfigureServices" /> registers.
    ///     A service with a missing dependency makes this fail, so it is found when the application starts.
    /// </summary>
    /// <returns>The service provider.</returns>
    private ServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        return services.BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true });
    }
}