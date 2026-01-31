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

using FrontendMentor.EntertainmentApp.Interfaces.ViewModels;
using FrontendMentor.EntertainmentApp.Interfaces.Views;

namespace FrontendMentor.EntertainmentApp.ViewModels.TabItems;

internal sealed class SeriesTabItemViewModel : TabItemViewModel, ISeriesTabItemViewModel
{
    public SeriesTabItemViewModel(ISeriesTabItemView seriesTabItemView) : base(seriesTabItemView)
    {
    }

    public override string Header => "TV Series";
}