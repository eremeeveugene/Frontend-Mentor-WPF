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
using FrontendMentor.Core.Common;
using FrontendMentor.EntertainmentApp.Interfaces;
using FrontendMentor.EntertainmentApp.ViewModels.TabItems;

namespace FrontendMentor.EntertainmentApp.ViewModels;

internal sealed class EntertainmentAppWindowViewModel : ObservableObject
{
    public EntertainmentAppWindowViewModel(IContainer container)
    {
        ITabItem[] tabItems =
        [
            container.Resolve<HomeTabItemViewModel>(),
            container.Resolve<MoviesTabItemViewModel>(),
            container.Resolve<SeriesTabItemViewModel>(),
            container.Resolve<BookmarksTabItemViewModel>()
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