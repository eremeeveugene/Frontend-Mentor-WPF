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

namespace FrontendMentor.ResultsSummaryComponent.Models;

/// <summary>
///     The data of a result summary.
/// </summary>
internal sealed class ResultSummaryModel
{
    /// <summary>
    ///     Gets or initializes the total score as a number.
    /// </summary>
    public required int NumberScore { get; init; }
    /// <summary>
    ///     Gets or initializes the total score as a text.
    /// </summary>
    public required string TextScore { get; init; }
    /// <summary>
    ///     Gets or initializes the percent of the users that the result outperforms.
    /// </summary>
    public required int PerformancePercent { get; init; }
    /// <summary>
    ///     Gets or initializes the summary items.
    /// </summary>
    public required IReadOnlyList<SummaryItemModel> SummaryItems { get; init; }
}