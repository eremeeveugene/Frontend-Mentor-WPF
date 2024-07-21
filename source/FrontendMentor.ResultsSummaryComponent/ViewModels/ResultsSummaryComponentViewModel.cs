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
using Prism.Ioc;
using Prism.Regions;

namespace FrontendMentor.ResultsSummaryComponent.ViewModels;

internal sealed class ResultsSummaryComponentViewModel(
    IContainerProvider containerProvider,
    IResultSummaryService resultSummaryService)
    : NavigationViewModelBase
{
    private ResultSummaryBindableModel? _resultSummary;

    public ResultSummaryBindableModel? ResultSummary
    {
        get => _resultSummary;
        private set => SetProperty(ref _resultSummary, value);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        var resultSummary = resultSummaryService.GetResultSummary();

        ResultSummary = ResultSummaryBindableModel.Create(containerProvider,
            new ResultSummaryBindableModel.Parameters { ResultSummary = resultSummary });
    }
}