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

using FrontendMentor.ResultsSummaryComponent.Enums;
using FrontendMentor.ResultsSummaryComponent.Models;

namespace FrontendMentor.ResultsSummaryComponent.BindableModels;

internal sealed class SummaryItemBindableModel(SummaryItemBindableModel.Parameters parameters) : BindableBase
{
    public SummaryItemType SummaryItemType { get; } = parameters.SummaryItem.SummaryItemType;

    public int Value { get; } = parameters.SummaryItem.Value;

    public static SummaryItemBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<SummaryItemBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(SummaryItemModel SummaryItem);
}