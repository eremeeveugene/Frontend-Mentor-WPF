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
using FrontendMentor.MortgageRepaymentCalculator.Properties;

namespace FrontendMentor.MortgageRepaymentCalculator.Enums;

internal enum MortgageType
{
    [LocalizedDescription(nameof(Resources.MortgageType_Repayment), typeof(Resources), "Repayment")]
    Repayment,
    [LocalizedDescription(nameof(Resources.MortgageType_InterestOnly), typeof(Resources), "Interest Only")]
    InterestOnly
}