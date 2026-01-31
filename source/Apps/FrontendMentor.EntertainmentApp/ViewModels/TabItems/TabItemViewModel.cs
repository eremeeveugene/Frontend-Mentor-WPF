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
using FrontendMentor.EntertainmentApp.Interfaces.Views;

namespace FrontendMentor.EntertainmentApp.ViewModels.TabItems;

internal abstract class TabItemViewModel : ObservableObject, ITabItem
{
    protected TabItemViewModel(IView view)
    {
        View = view;
    }

    public IView View { get; }
    public abstract string Header { get; }
}