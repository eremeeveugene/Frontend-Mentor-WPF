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

using FrontendMentor.ThreeColumnPreviewCardComponent.Constants;
using FrontendMentor.ThreeColumnPreviewCardComponent.Controls.Windows;
using FrontendMentor.ThreeColumnPreviewCardComponent.Views;
using System.Windows;

namespace FrontendMentor.ThreeColumnPreviewCardComponent;

internal partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterForNavigation<ThreeColumnPreviewCardComponentView>(
            ThreeColumnPreviewCardComponentViewNames.ThreeColumnPreviewCardComponent);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<ThreeColumnPreviewCardComponentWindow>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigateToShellRegion(ThreeColumnPreviewCardComponentViewNames.ThreeColumnPreviewCardComponent);
    }
}