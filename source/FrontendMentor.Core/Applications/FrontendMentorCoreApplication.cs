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
using FrontendMentor.Core.Extensions;
using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.Core.Services.Processes;
using System.Windows;

namespace FrontendMentor.Core.Applications;

public abstract class FrontendMentorCoreApplication : Application
{
    protected FrontendMentorCoreApplication()
    {
        Container = BuildContainer();
    }

    protected IContainer Container { get; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = GetMainWindow();

        MainWindow = mainWindow;

        mainWindow.Show();
    }

    protected abstract Window GetMainWindow();

    protected Window GetWindow<TWindow, TViewModel>()
        where TWindow : IWindow
        where TViewModel : notnull
    {
        var windowViewModel = Container.Resolve<TViewModel>();
        var windowView = Container.Resolve<TWindow>();

        windowView.DataContext = windowViewModel;

        return windowView as Window
               ?? throw new InvalidOperationException(
                   $"Type '{windowView.GetType().FullName}' resolved for '{typeof(TWindow).FullName}' " +
                   $"must inherit from '{typeof(Window).FullName}' to be used as a main window.");
    }

    private Container BuildContainer()
    {
        var container = new Container(rules => rules
            .WithAutoConcreteTypeResolution()
            .WithMicrosoftDependencyInjectionRules());

        container.RegisterSingleton<IProcessesService, ProcessesService>();
        container.RegisterSingleton<IBitmapImagesService, BitmapImagesService>();

        RegisterTypes(container);

        return container;
    }

    protected virtual void RegisterTypes(IContainer container)
    {
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        Container.Dispose();
    }
}