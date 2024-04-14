// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Core.ViewModels;
using FrontendMentor.ResultsSummaryComponent.BindableModels;
using FrontendMentor.ResultsSummaryComponent.Services.ResultSummary;

namespace FrontendMentor.ResultsSummaryComponent.ViewModels;

internal sealed class ResultsSummaryComponentSectorViewModel(IResultSummaryService resultSummaryService) : ViewModelBase
{
    private ResultSummaryBindableModel? _resultSummary;

    public ResultSummaryBindableModel? ResultSummary
    {
        get => _resultSummary;
        private set => SetProperty(ref _resultSummary, value);
    }

    protected override Task LoadedOnceAsync()
    {
        LoadResultSummary();

        return base.LoadedOnceAsync();
    }

    private void LoadResultSummary()
    {
        var resultSummary = resultSummaryService.GetResultSummary();

        ResultSummary = new ResultSummaryBindableModel(resultSummary);
    }
}