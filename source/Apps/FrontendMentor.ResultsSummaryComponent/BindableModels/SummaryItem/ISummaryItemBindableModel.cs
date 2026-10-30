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
using FrontendMentor.ResultsSummaryComponent.Enums;

namespace FrontendMentor.ResultsSummaryComponent.BindableModels.SummaryItem;

/// <summary>
///     The presentation model of a summary item.
/// </summary>
internal interface ISummaryItemBindableModel : IBindableModel
{
    /// <summary>
    ///     Gets the type of the summary item.
    /// </summary>
    SummaryItemType SummaryItemType { get; }

    /// <summary>
    ///     Gets the score of the summary item.
    /// </summary>
    int Value { get; }
}