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

using FrontendMentor.Core.BindableModels;
using FrontendMentor.ResultsSummaryComponent.BindableModels.SummaryItem;

namespace FrontendMentor.ResultsSummaryComponent.BindableModels.ResultSummary;

/// <summary>
///     The presentation model of a result summary.
/// </summary>
internal interface IResultSummaryBindableModel : IBindableModel
{
    /// <summary>
    ///     Gets the total score as a number.
    /// </summary>
    int NumberScore { get; }

    /// <summary>
    ///     Gets the total score as a text.
    /// </summary>
    string TextScore { get; }

    /// <summary>
    ///     Gets the percent of the users that the result outperforms.
    /// </summary>
    int PerformancePercent { get; }

    /// <summary>
    ///     Gets the summary items.
    /// </summary>
    IReadOnlyList<ISummaryItemBindableModel> SummaryItems { get; }
}