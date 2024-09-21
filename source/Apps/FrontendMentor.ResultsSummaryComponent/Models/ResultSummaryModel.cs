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

namespace FrontendMentor.ResultsSummaryComponent.Models;

internal class ResultSummaryModel
{
    public int NumberScore { get; set; }
    public string TextScore { get; set; } = null!;
    public int PerformancePercent { get; set; }
    public IEnumerable<SummaryItemModel> SummaryItems { get; set; } = null!;
}