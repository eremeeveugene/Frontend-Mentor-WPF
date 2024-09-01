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

using FrontendMentor.ResultsSummaryComponent.Models;

namespace FrontendMentor.ResultsSummaryComponent.BindableModels;

internal sealed class ResultSummaryBindableModel(
    IContainerProvider containerProvider,
    ResultSummaryBindableModel.Parameters parameters) : BindableBase
{
    public int NumberScore { get; } = parameters.ResultSummary.NumberScore;

    public string TextScore { get; } = parameters.ResultSummary.TextScore;

    public int PerformancePercent { get; } = parameters.ResultSummary.PerformancePercent;

    public List<SummaryItemBindableModel> SummaryItems { get; } =
        GetSummaryItems(containerProvider, parameters.ResultSummary.SummaryItems);

    private static List<SummaryItemBindableModel> GetSummaryItems(IContainerProvider containerProvider,
        IEnumerable<SummaryItemModel> summaryItems)
    {
        return summaryItems.Select(summaryItem => SummaryItemBindableModel.Create(containerProvider,
            new SummaryItemBindableModel.Parameters(summaryItem))).ToList();
    }

    public static ResultSummaryBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<ResultSummaryBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(ResultSummaryModel ResultSummary);
}