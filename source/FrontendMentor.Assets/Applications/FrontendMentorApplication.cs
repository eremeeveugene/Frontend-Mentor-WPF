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

using FrontendMentor.Assets.Enums;
using FrontendMentor.Assets.Services.Themes;
using FrontendMentor.Core.Applications;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.Assets.Applications;

/// <summary>
///     The base application that adds theming to <see cref="FrontendMentorCoreApplication" />.
/// </summary>
public abstract class FrontendMentorApplication : FrontendMentorCoreApplication
{
    /// <inheritdoc />
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddSingleton<INativeWindowThemeService, NativeWindowThemeService>()
            .AddSingleton<IThemeService, ThemeService>();
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        // ToDo: Get system value
        ServiceProvider.GetRequiredService<IThemeService>().SetTheme(Theme.Dark);

        base.OnInitialized();
    }
}