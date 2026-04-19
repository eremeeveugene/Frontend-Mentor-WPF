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
using FrontendMentor.EntertainmentApp.Interfaces.ViewModels;
using FrontendMentor.EntertainmentApp.Interfaces.Views;
using FrontendMentor.EntertainmentApp.ViewModels;
using FrontendMentor.EntertainmentApp.ViewModels.TabItems;
using FrontendMentor.EntertainmentApp.Views;
using FrontendMentor.EntertainmentApp.Views.TabItems;
using System.Windows;

namespace FrontendMentor.EntertainmentApp;

internal sealed partial class App
{
    protected override Window GetMainWindow()
    {
        return GetWindow<IEntertainmentAppWindowView, IEntertainmentAppWindowViewModel>();
    }

    protected override void RegisterTypes(IContainer container)
    {
        base.RegisterTypes(container);

        container.Register<IEntertainmentAppWindowView, EntertainmentAppWindowView>();
        container.Register<IEntertainmentAppWindowViewModel, EntertainmentAppWindowViewModel>();
        container.Register<IBookmarksTabItemView, BookmarksTabItemView>();
        container.Register<IBookmarksTabItemViewModel, BookmarksTabItemViewModel>();
        container.Register<IHomeTabItemView, HomeTabItemView>();
        container.Register<IHomeTabItemViewModel, HomeTabItemViewModel>();
        container.Register<IMoviesTabItemView, MoviesTabItemView>();
        container.Register<IMoviesTabItemViewModel, MoviesTabItemViewModel>();
        container.Register<ISeriesTabItemView, SeriesTabItemView>();
        container.Register<ISeriesTabItemViewModel, SeriesTabItemViewModel>();
    }
}