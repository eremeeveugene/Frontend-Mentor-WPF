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

using FrontendMentor.ResultsSummaryComponent.BindableModels.ResultSummary;
using FrontendMentor.ResultsSummaryComponent.Models.ResultSummaries;

namespace FrontendMentor.ResultsSummaryComponent.Factories.ResultSummary;

/// <summary>
///     Creates the presentation models of result summaries.
/// </summary>
internal interface IResultSummaryBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of a result summary.
    /// </summary>
    /// <param name="resultSummary">The data of a result summary.</param>
    /// <returns>The presentation model.</returns>
    IResultSummaryBindableModel Create(ResultSummaryModel resultSummary);
}