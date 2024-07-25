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

using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.Core.Services.Processes;
using FrontendMentor.Core.Services.WindowsApi.Dwm;
using FrontendMentor.Core.Services.WindowsApi.User32;
using FrontendMentor.Core.Services.WindowsVersion;
using Prism.DryIoc;
using Prism.Ioc;

namespace FrontendMentor.Core.Applications;

public abstract class FrontendMentorCoreApplication : PrismApplication
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IProcessesService, ProcessesService>();
        containerRegistry.RegisterSingleton<IBitmapImagesService, BitmapImagesService>();
        containerRegistry.RegisterSingleton<IDwmApiService, DwmApiService>();
        containerRegistry.RegisterSingleton<IWindowsVersionService, WindowsVersionService>();
        containerRegistry.RegisterSingleton<IUser32ApiService, User32ApiService>();
    }
}