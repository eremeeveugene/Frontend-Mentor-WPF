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

namespace FrontendMentor.ResultsSummaryComponent.Services.ResultSummary;

internal class ResultSummaryService : IResultSummaryService
{
    public ResultSummaryModel GetResultSummary()
    {
        return new ResultSummaryModel
        {
            Result = 76,
            ExceededPercent = 65,
            SummaryItems = new List<SummaryItemModel>
            {
                new() { SummaryItemType = SummaryItemType.Reaction, Value = 80 },
                new() { SummaryItemType = SummaryItemType.Memory, Value = 92 },
                new() { SummaryItemType = SummaryItemType.Verbal, Value = 61 },
                new() { SummaryItemType = SummaryItemType.Visual, Value = 73 }
            }
        };
    }
}