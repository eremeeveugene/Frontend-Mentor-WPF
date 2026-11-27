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

using FrontendMentor.Core.BindableModels;

namespace FrontendMentor.MortgageRepaymentCalculator.BindableModels.MortgageRepayment;

/// <summary>
///     The presentation model of the repayments of a mortgage.
/// </summary>
internal interface IMortgageRepaymentBindableModel : IBindableModel
{
    /// <summary>
    ///     Gets the repayment per month.
    /// </summary>
    decimal MonthlyRepayment { get; }

    /// <summary>
    ///     Gets the total repaid over the term.
    /// </summary>
    decimal TotalRepayment { get; }
}