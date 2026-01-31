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

using FrontendMentor.EntertainmentApp.ViewModels.Tabs;

namespace FrontendMentor.EntertainmentApp.ViewModels;

internal sealed class EntertainmentAppWindowViewModel
{
    public IReadOnlyCollection<TabItemViewModel> Tabs
    {
        get;
    }

    public EntertainmentAppWindowViewModel()
    {
        Tabs = new TabItemViewModel[]
        {
            new HomeTabItemViewModel(),
            new MoviesTabItemViewModel(),
            new SeriesTabItemViewModel(),
            new BookmarksTabItemViewModel(),
        };
    }
}