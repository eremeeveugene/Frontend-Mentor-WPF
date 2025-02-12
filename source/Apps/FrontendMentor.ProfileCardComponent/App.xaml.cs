// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.ProfileCardComponent.Constants;
using FrontendMentor.ProfileCardComponent.Controls.Windows;
using FrontendMentor.ProfileCardComponent.Views;
using System.Windows;

namespace FrontendMentor.ProfileCardComponent;

internal partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<ProfileCardComponentWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterForNavigation<ProfileCardComponentView>(ProfileCardComponentViewNames
            .ProfileCardComponent);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigateToShellRegion(ProfileCardComponentViewNames.ProfileCardComponent);
    }
}