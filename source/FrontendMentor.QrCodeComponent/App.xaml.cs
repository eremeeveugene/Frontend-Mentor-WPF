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
using FrontendMentor.QrCodeComponent.Constants;
using FrontendMentor.QrCodeComponent.Controls;
using FrontendMentor.QrCodeComponent.Views;
using Prism.Ioc;
using System.Windows;

namespace FrontendMentor.QrCodeComponent;

internal partial class App
{
    protected override void RegisterSectors(ISectorsService sectorsService)
    {
        base.RegisterSectors(sectorsService);

        sectorsService.RegisterSectorView<QrCodeComponentSectorView>(QrCodeComponentSectorNames
            .QrCodeComponentSector);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<QrCodeComponentWindow>();
    }

    protected override void OnInitialized()
    {
        var sectorsService = Container.Resolve<ISectorsService>();

        sectorsService.NavigateToSectorView(QrCodeComponentSectorNames.QrCodeComponentSector);

        base.OnInitialized();
    }
}