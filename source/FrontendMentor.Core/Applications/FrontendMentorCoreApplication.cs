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
using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.Core.Services.Processes;
using System.Windows;

namespace FrontendMentor.Core.Applications;

public abstract class FrontendMentorCoreApplication : Application
{
    protected readonly IContainer Container;

    protected FrontendMentorCoreApplication()
    {
        Container = BuildContainer();
    }

    private IContainer BuildContainer()
    {
        var container = new Container();

        container.Register<IProcessesService, ProcessesService>(Reuse.Singleton);
        container.Register<IBitmapImagesService, BitmapImagesService>(Reuse.Singleton);

        RegisterTypes(container);

        return container;
    }

    protected virtual void RegisterTypes(IContainer container)
    {
    }
}