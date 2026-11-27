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

namespace FrontendMentor.MortgageRepaymentCalculator.Models.MortgageRepayments;

/// <summary>
///     The data of the repayments of a mortgage.
/// </summary>
internal sealed class MortgageRepaymentModel
{
    /// <summary>
    ///     Gets or initializes the repayment per month.
    /// </summary>
    public required decimal MonthlyRepayment { get; init; }

    /// <summary>
    ///     Gets or initializes the total repaid over the term.
    /// </summary>
    public required decimal TotalRepayment { get; init; }
}