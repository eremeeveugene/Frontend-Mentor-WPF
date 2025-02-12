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

namespace FrontendMentor.ProfileCardComponent;

internal partial class App
{
    //protected override Window CreateShell()
    //{
    //    return Container.Resolve<QrCodeComponentWindow>();
    //}

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        //containerRegistry.RegisterForNavigation<QrCodeComponentView>(QrCodeComponentViewNames.QrCodeComponent);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        //NavigateToShellRegion(QrCodeComponentViewNames.QrCodeComponent);
    }
}