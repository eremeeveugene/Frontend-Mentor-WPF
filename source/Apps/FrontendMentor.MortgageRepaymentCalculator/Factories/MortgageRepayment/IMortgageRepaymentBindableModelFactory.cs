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

using FrontendMentor.MortgageRepaymentCalculator.BindableModels.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageRepayments;

namespace FrontendMentor.MortgageRepaymentCalculator.Factories.MortgageRepayment;

/// <summary>
///     Creates the presentation models of mortgage repayments.
/// </summary>
internal interface IMortgageRepaymentBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of the repayments of a mortgage.
    /// </summary>
    /// <param name="mortgageRepayment">The repayments of a mortgage.</param>
    /// <returns>The presentation model.</returns>
    IMortgageRepaymentBindableModel Create(MortgageRepaymentModel mortgageRepayment);
}