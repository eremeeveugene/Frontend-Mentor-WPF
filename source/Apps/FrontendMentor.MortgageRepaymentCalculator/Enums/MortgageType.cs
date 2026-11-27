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

namespace FrontendMentor.MortgageRepaymentCalculator.Enums;

/// <summary>
///     The type of a mortgage.
/// </summary>
internal enum MortgageType
{
    /// <summary>
    ///     The monthly repayments pay back the interest and the amount.
    /// </summary>
    Repayment,

    /// <summary>
    ///     The monthly repayments pay back only the interest.
    /// </summary>
    InterestOnly
}