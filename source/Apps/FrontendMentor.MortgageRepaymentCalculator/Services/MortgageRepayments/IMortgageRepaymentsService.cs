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

using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageRepayments;
using FrontendMentor.MortgageRepaymentCalculator.Models.Mortgages;

namespace FrontendMentor.MortgageRepaymentCalculator.Services.MortgageRepayments;

/// <summary>
///     Provides mortgage repayments.
/// </summary>
internal interface IMortgageRepaymentsService
{
    /// <summary>
    ///     Gets the repayments of a mortgage.
    /// </summary>
    /// <param name="mortgage">The mortgage.</param>
    /// <param name="cancellationToken">The token that cancels the request.</param>
    /// <returns>A task that completes with the monthly and the total repayment.</returns>
    /// <remarks>
    ///     The method is asynchronous to simulate retrieving the repayments from a backend service.
    ///     The repayments are calculated locally, so the task completes immediately.
    /// </remarks>
    Task<MortgageRepaymentModel> GetMortgageRepaymentAsync(MortgageModel mortgage, CancellationToken cancellationToken = default);
}