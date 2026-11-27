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

using FrontendMentor.OrderSummaryComponent.BindableModels.OrderSummary;
using FrontendMentor.OrderSummaryComponent.Models.AnnualPlans;

namespace FrontendMentor.OrderSummaryComponent.Factories.OrderSummary;

/// <summary>
///     Creates the presentation models of order summaries.
/// </summary>
internal interface IOrderSummaryBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of an order summary.
    /// </summary>
    /// <param name="annualPlan">The annual plan that is ordered.</param>
    /// <returns>The presentation model.</returns>
    IOrderSummaryBindableModel Create(AnnualPlanModel annualPlan);
}