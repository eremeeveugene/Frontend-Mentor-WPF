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

namespace FrontendMentor.OrderSummaryComponent.Models.AnnualPlans;

/// <summary>
///     The data of an annual plan.
/// </summary>
internal sealed class AnnualPlanModel
{
    /// <summary>
    ///     Gets or initializes the price per year.
    /// </summary>
    public required double Price { get; init; }
}