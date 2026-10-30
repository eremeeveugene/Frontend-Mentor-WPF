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

namespace FrontendMentor.ResultsSummaryComponent.BindableModels.ResultSummary;

/// <inheritdoc cref="IResultSummaryBindableModel" />
internal sealed class ResultSummaryBindableModel : BindableBase, IResultSummaryBindableModel
{
    public ResultSummaryBindableModel(
        Func<SummaryItemBindableModelParameters, ISummaryItemBindableModel> summaryItemFactory,
        ResultSummaryBindableModelParameters parameters)
    {
        var resultSummary = parameters.ResultSummary;

        NumberScore = resultSummary.NumberScore;
        TextScore = resultSummary.TextScore;
        PerformancePercent = resultSummary.PerformancePercent;

        var summaryItems = new List<ISummaryItemBindableModel>(resultSummary.SummaryItems.Count);

        foreach (var summaryItem in resultSummary.SummaryItems)
        {
            summaryItems.Add(summaryItemFactory(new SummaryItemBindableModelParameters(summaryItem)));
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