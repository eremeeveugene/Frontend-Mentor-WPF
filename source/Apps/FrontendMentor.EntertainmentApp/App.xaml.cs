// --------------------------------------------------------------------------------
// Copyright (C) 2026 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using DryIoc;
using FrontendMentor.EntertainmentApp.Views;
using System.Windows;

namespace FrontendMentor.EntertainmentApp;

internal sealed partial class App
{
    protected override Window GetMainWindow()
    {
        return GetWindow<EntertainmentAppWindowView>();
    }

    protected override void RegisterTypes(IContainer container)
    {
        base.RegisterTypes(container);

        //container.RegisterSingleton<IBlogsService, BlogsService>();
        //container.RegisterSingleton<IBlogBindableModelFactory, BlogBindableModelFactory>();
    }
}