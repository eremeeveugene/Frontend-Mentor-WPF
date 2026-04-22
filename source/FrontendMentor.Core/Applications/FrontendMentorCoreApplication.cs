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
using DryIoc.Microsoft.DependencyInjection;
using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.Core.Services.Processes;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace FrontendMentor.Core.Applications;

public abstract class FrontendMentorCoreApplication : Application
{
    private readonly IContainer _container;

    protected FrontendMentorCoreApplication()
    {
        _container = CreateContainer();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = GetMainWindow();

        MainWindow = mainWindow;

        mainWindow.Show();
    }

    protected abstract Window GetMainWindow();

    protected Window GetWindow<TWindow, TViewModel>() where TWindow : IWindow where TViewModel : notnull
    {
        var windowViewModel = _container.Resolve<TViewModel>();
        var windowView = _container.Resolve<TWindow>();

        windowView.DataContext = windowViewModel;

        return windowView as Window ?? throw new InvalidOperationException(
            $"Type '{windowView.GetType().FullName}' resolved for '{typeof(TWindow).FullName}' " +
            $"must inherit from '{typeof(Window).FullName}' to be used as a main window.");
    }

    private IContainer CreateContainer()
    {
        var serviceCollection = CreateServiceCollection();

        return new Container(rules => rules.WithAutoConcreteTypeResolution().WithMicrosoftDependencyInjectionRules())
            .WithDependencyInjectionAdapter(serviceCollection);
    }

    private ServiceCollection CreateServiceCollection()
    {
        var serviceCollection = new ServiceCollection();

        AddRequiredServices(serviceCollection);
        AddServices(serviceCollection);

        return serviceCollection;
    }

    private static void AddRequiredServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IProcessesService, ProcessesService>();
        serviceCollection.AddSingleton<IBitmapImagesService, BitmapImagesService>();
    }

    protected virtual void AddServices(IServiceCollection serviceCollection)
    {
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        _container.Dispose();
    }
}