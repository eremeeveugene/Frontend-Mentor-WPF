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
using FrontendMentor.ResultsSummaryComponent.Factories.ResultSummary;
using FrontendMentor.ResultsSummaryComponent.Services.ResultSummaries;

namespace FrontendMentor.ResultsSummaryComponent.ViewModels.ResultsSummaryComponent;

/// <inheritdoc cref="IResultsSummaryComponentViewModel" />
internal sealed class ResultsSummaryComponentViewModel : BindableBase, IResultsSummaryComponentViewModel
{
    private readonly IResultSummaryBindableModelFactory _resultSummaryFactory;
    private readonly IResultSummariesService _resultSummariesService;

    public ResultsSummaryComponentViewModel(
        IResultSummaryBindableModelFactory resultSummaryFactory,
        IResultSummariesService resultSummariesService)
    {
        _resultSummaryFactory = resultSummaryFactory;
        _resultSummariesService = resultSummariesService;
    }

    /// <inheritdoc />
    public IResultSummaryBindableModel? ResultSummary
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public async Task LoadAsync(CancellationToken cancellationToken)
    {
        var resultSummary = await _resultSummariesService.GetResultSummaryAsync(cancellationToken);

        ResultSummary = _resultSummaryFactory.Create(resultSummary);
    }
}