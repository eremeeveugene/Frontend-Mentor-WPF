// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.ResultsSummaryComponent.Models;

namespace FrontendMentor.ResultsSummaryComponent.Services.ResultSummary;

/// <summary>
///     Provides result summaries.
/// </summary>
internal interface IResultSummaryService
{
    /// <summary>
    ///     Gets the result summary that the view shows.
    /// </summary>
    /// <returns>The result summary.</returns>
    ResultSummaryModel GetResultSummary();
}