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

using FrontendMentor.Core.Services.Sectors;
using FrontendMentor.Core.Services.SectorsContainerRegistry;
using FrontendMentor.QrCodeComponent.Constants;
using FrontendMentor.QrCodeComponent.Controls;
using FrontendMentor.QrCodeComponent.Views;
using Prism.Ioc;
using System.Windows;

namespace FrontendMentor.QrCodeComponent;

internal partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterSector<QrCodeComponentSectorView>(QrCodeComponentSectorNames
            .QrCodeComponentSector);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<QrCodeComponentWindow>();
    }

    protected override void OnInitialized()
    {
        var sectorsService = Container.Resolve<ISectorsService>();

        sectorsService.NavigateToSector(QrCodeComponentSectorNames.QrCodeComponentSector);

        base.OnInitialized();
    }
}