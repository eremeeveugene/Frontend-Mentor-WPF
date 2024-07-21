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

using FrontendMentor.Core.Attributes;
using FrontendMentor.ResultsSummaryComponent.Properties;

namespace FrontendMentor.ResultsSummaryComponent.Enums;

internal enum SummaryItemType
{
    [LocalizedDescription(nameof(Resources.SummaryItemType_Reaction), typeof(Resources), "Reaction")]
    Reaction,

    [LocalizedDescription(nameof(Resources.SummaryItemType_Memory), typeof(Resources), "Memory")]
    Memory,

    [LocalizedDescription(nameof(Resources.SummaryItemType_Verbal), typeof(Resources), "Verbal")]
    Verbal,

    [LocalizedDescription(nameof(Resources.SummaryItemType_Visual), typeof(Resources), "Visual")]
    Visual
}