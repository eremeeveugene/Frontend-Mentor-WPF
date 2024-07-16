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

using FrontendMentor.ResultsSummaryComponent.Constants;
using FrontendMentor.ResultsSummaryComponent.Controls.Windows;
using FrontendMentor.ResultsSummaryComponent.Services.ResultSummary;
using FrontendMentor.ResultsSummaryComponent.Views;
using Prism.Ioc;
using System.Windows;

namespace FrontendMentor.ResultsSummaryComponent;

internal partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterSingleton<IResultSummaryService, ResultSummaryService>();
        containerRegistry.RegisterForNavigation<ResultsSummaryComponentView>(ResultsSummaryComponentViewNames
            .ResultsSummaryComponent);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<ResultsSummaryComponentWindow>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigateToShellRegion(ResultsSummaryComponentViewNames.ResultsSummaryComponent);
    }
}