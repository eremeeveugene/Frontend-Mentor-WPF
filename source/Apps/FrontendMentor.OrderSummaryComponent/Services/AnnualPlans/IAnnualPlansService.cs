// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.OrderSummaryComponent.Models.AnnualPlans;

namespace FrontendMentor.OrderSummaryComponent.Services.AnnualPlans;

/// <summary>
///     Provides annual plans.
/// </summary>
internal interface IAnnualPlansService
{
    /// <summary>
    ///     Gets the annual plan that the order summary shows.
    /// </summary>
    /// <param name="cancellationToken">The token that cancels the request.</param>
    /// <returns>A task that completes with the annual plan.</returns>
    /// <remarks>
    ///     The method is asynchronous to simulate retrieving the annual plan from a backend service.
    ///     The data is local, so the task completes immediately.
    /// </remarks>
    Task<AnnualPlanModel> GetAnnualPlanAsync(CancellationToken cancellationToken = default);
}