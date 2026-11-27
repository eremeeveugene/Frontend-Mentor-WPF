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
using FrontendMentor.ResultsSummaryComponent.BindableModels.SummaryItem;
using FrontendMentor.ResultsSummaryComponent.Factories.SummaryItem;
using FrontendMentor.ResultsSummaryComponent.Models.ResultSummaries;

namespace FrontendMentor.ResultsSummaryComponent.BindableModels.ResultSummary;

/// <inheritdoc cref="IResultSummaryBindableModel" />
internal sealed class ResultSummaryBindableModel : BindableBase, IResultSummaryBindableModel
{
    public ResultSummaryBindableModel(
        ISummaryItemBindableModelFactory summaryItemFactory,
        ResultSummaryModel resultSummary)
    {
        NumberScore = resultSummary.NumberScore;
        TextScore = resultSummary.TextScore;
        PerformancePercent = resultSummary.PerformancePercent;

        var summaryItemModels = resultSummary.SummaryItems;
        var summaryItems = new ISummaryItemBindableModel[summaryItemModels.Count];

        for (var i = 0; i < summaryItems.Length; i++)
        {
            summaryItems[i] = summaryItemFactory.Create(summaryItemModels[i]);
        }

        SummaryItems = summaryItems;
    }

    /// <inheritdoc />
    public int NumberScore { get; }

    /// <inheritdoc />
    public string TextScore { get; }

    /// <inheritdoc />
    public int PerformancePercent { get; }

    /// <inheritdoc />
    public IReadOnlyList<ISummaryItemBindableModel> SummaryItems { get; }
}