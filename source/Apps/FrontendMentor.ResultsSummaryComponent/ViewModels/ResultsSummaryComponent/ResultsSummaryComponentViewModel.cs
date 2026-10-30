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

using FrontendMentor.Core.Bindables;
using FrontendMentor.ResultsSummaryComponent.BindableModels.ResultSummary;
using FrontendMentor.ResultsSummaryComponent.Services.ResultSummary;

namespace FrontendMentor.ResultsSummaryComponent.ViewModels.ResultsSummaryComponent;

/// <inheritdoc cref="IResultsSummaryComponentViewModel" />
internal sealed class ResultsSummaryComponentViewModel
    : BindableBase,
        IResultsSummaryComponentViewModel
{
    public ResultsSummaryComponentViewModel(
        Func<ResultSummaryBindableModelParameters, IResultSummaryBindableModel> resultSummaryFactory,
        IResultSummaryService resultSummaryService)
    {
        ResultSummary = resultSummaryFactory(new ResultSummaryBindableModelParameters(resultSummaryService.GetResultSummary()));
    }

    /// <inheritdoc />
    public IResultSummaryBindableModel ResultSummary { get; }
}