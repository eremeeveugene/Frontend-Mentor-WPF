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


using FrontendMentor.ResultsSummaryComponent.Models.ResultSummaries;

namespace FrontendMentor.ResultsSummaryComponent.Services.ResultSummaries;

/// <summary>
///     Provides result summaries.
/// </summary>
internal interface IResultSummariesService
{
    /// <summary>
    ///     Gets the result summary that the view shows.
    /// </summary>
    /// <param name="cancellationToken">The token that cancels the request.</param>
    /// <returns>A task that completes with the result summary.</returns>
    /// <remarks>
    ///     The method is asynchronous to simulate retrieving the result summary from a backend service.
    ///     The data is local, so the task completes immediately.
    /// </remarks>
    Task<ResultSummaryModel> GetResultSummaryAsync(CancellationToken cancellationToken = default);
}