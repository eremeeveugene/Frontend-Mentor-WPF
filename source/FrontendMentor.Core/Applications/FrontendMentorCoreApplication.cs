// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Core.Services.Processes;
using FrontendMentor.Core.Services.Sectors;
using FrontendMentor.Core.Services.SectorsContainerRegistry;
using Prism.DryIoc;
using Prism.Ioc;

namespace FrontendMentor.Core.Applications;

public abstract class FrontendMentorCoreApplication : PrismApplication
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IProcessesService, ProcessesService>();
        containerRegistry.RegisterSingleton<ISectorsService, SectorsService>();
        //containerRegistry.RegisterSingleton<ISectorsContainerRegistry, SectorsContainerRegistry>();
    }

    //protected override void Initialize()
    //{
    //    base.Initialize();

    //    RegisterSectors(Container.Resolve<ISectorsContainerRegistry>());
    //}


}