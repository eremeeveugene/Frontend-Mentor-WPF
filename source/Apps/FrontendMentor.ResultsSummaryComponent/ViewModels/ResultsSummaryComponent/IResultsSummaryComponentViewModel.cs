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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.ResultsSummaryComponent.BindableModels.ResultSummary;

namespace FrontendMentor.ResultsSummaryComponent.ViewModels.ResultsSummaryComponent;

/// <summary>
///     The view model of the results summary.
/// </summary>
internal interface IResultsSummaryComponentViewModel : IViewModel
{
    /// <summary>
    ///     Gets the result summary that the view shows.
    /// </summary>
    IResultSummaryBindableModel ResultSummary { get; }
}