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

using FrontendMentor.Core.Common;
using FrontendMentor.EntertainmentApp.Interfaces;
using FrontendMentor.EntertainmentApp.Interfaces.ViewModels;

namespace FrontendMentor.EntertainmentApp.ViewModels;

internal sealed class EntertainmentAppWindowViewModel : BindableBase, IEntertainmentAppWindowViewModel
{
    public EntertainmentAppWindowViewModel(
        IHomeTabItemViewModel homeTabItemViewMode,
        IMoviesTabItemViewModel moviesTabItemViewModel,
        ISeriesTabItemViewModel seriesTabItemViewModel,
        IBookmarksTabItemViewModel bookmarksTabItemViewModel)
    {
        ITabItem[] tabItems =
        [
            homeTabItemViewMode, moviesTabItemViewModel, seriesTabItemViewModel, bookmarksTabItemViewModel
        ];

        TabItems = tabItems;
        SelectedTabItem = tabItems[0];
    }

    public IReadOnlyCollection<ITabItem> TabItems { get; }

    public ITabItem SelectedTabItem
    {
        get;
        set => SetProperty(ref field, value);
    }
}