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

namespace FrontendMentor.OrderSummaryComponent.Services.AnnualPlan;

/// <summary>
///     Provides the annual plan.
/// </summary>
internal interface IAnnualPlanService
{
    /// <summary>
    ///     Gets the price of the annual plan.
    /// </summary>
    /// <returns>The price of the annual plan.</returns>
    double GetAnnualPlanPrice();
}