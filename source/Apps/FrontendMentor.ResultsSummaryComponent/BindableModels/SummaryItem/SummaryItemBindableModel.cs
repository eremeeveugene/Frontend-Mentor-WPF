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

using FrontendMentor.Core.Bindables;
using FrontendMentor.ResultsSummaryComponent.Enums;

namespace FrontendMentor.ResultsSummaryComponent.BindableModels.SummaryItem;

/// <inheritdoc cref="ISummaryItemBindableModel" />
internal sealed class SummaryItemBindableModel : BindableBase, ISummaryItemBindableModel
{
    public SummaryItemBindableModel(SummaryItemBindableModelParameters parameters)
    {
        var summaryItem = parameters.SummaryItem;

        SummaryItemType = summaryItem.SummaryItemType;
        Value = summaryItem.Value;
    }

    /// <inheritdoc />
    public SummaryItemType SummaryItemType { get; }

    /// <inheritdoc />
    public int Value { get; }
}