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

using FrontendMentor.ResultsSummaryComponent.Enums;

namespace FrontendMentor.ResultsSummaryComponent.Models;

/// <summary>
///     The data of a summary item.
/// </summary>
internal sealed class SummaryItemModel
{
    /// <summary>
    ///     Gets or initializes the type of the summary item.
    /// </summary>
    public required SummaryItemType SummaryItemType { get; init; }
    /// <summary>
    ///     Gets or initializes the score of the summary item.
    /// </summary>
    public required int Value { get; init; }
}