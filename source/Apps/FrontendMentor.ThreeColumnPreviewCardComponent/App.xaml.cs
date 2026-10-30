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

using FrontendMentor.Core.Extensions;
using FrontendMentor.ThreeColumnPreviewCardComponent.Controls.Windows;
using FrontendMentor.ThreeColumnPreviewCardComponent.Views.ThreeColumnPreviewCardComponent;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.ThreeColumnPreviewCardComponent;

/// <summary>
///     The application entry point.
/// </summary>
internal sealed partial class App
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddMainWindow<IThreeColumnPreviewCardComponentWindow, ThreeColumnPreviewCardComponentWindow>()
            .AddTransient<IThreeColumnPreviewCardComponentView, ThreeColumnPreviewCardComponentView>();
    }
}