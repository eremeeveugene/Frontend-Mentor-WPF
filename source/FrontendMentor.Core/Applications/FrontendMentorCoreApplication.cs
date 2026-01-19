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
    private readonly Container _container;

    protected FrontendMentorCoreApplication()
    {
        _container = BuildContainer();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = GetMainWindow();

        MainWindow = mainWindow;

        mainWindow.Show();
    }

    protected abstract Window GetMainWindow();

    protected Window GetWindow<T>() where T : Window
    {
        return _container.Resolve<T>();
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

        _container.Dispose();
    }
}