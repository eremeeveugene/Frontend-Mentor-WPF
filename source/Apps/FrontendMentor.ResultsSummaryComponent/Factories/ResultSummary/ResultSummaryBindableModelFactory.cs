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
using FrontendMentor.ResultsSummaryComponent.Factories.SummaryItem;
using FrontendMentor.ResultsSummaryComponent.Models.ResultSummaries;

namespace FrontendMentor.ResultsSummaryComponent.Factories.ResultSummary;

/// <inheritdoc />
internal sealed class ResultSummaryBindableModelFactory : IResultSummaryBindableModelFactory
{
    private readonly ISummaryItemBindableModelFactory _summaryItemFactory;

    public ResultSummaryBindableModelFactory(ISummaryItemBindableModelFactory summaryItemFactory)
    {
        _summaryItemFactory = summaryItemFactory;
    }

    /// <inheritdoc />
    public IResultSummaryBindableModel Create(ResultSummaryModel resultSummary)
    {
        return new ResultSummaryBindableModel(_summaryItemFactory, resultSummary);
    }
}