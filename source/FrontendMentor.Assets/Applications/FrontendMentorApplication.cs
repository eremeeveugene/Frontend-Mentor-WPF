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

using FrontendMentor.Assets.Controls.Sectors;
using FrontendMentor.Assets.Controls.Windows;
using FrontendMentor.Core.Applications;
using FrontendMentor.Core.Services.Sectors;
using Prism.Ioc;
using System.Windows;

namespace FrontendMentor.Assets.Applications;

public abstract class FrontendMentorApplication : FrontendMentorCoreApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<FrontendMentorWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterSingleton<ISectorsContainer, SectorsContainer>();
    }
}