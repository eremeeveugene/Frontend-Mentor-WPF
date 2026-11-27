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

/// <inheritdoc />
internal sealed class OrderSummaryBindableModelFactory : IOrderSummaryBindableModelFactory
{
    /// <inheritdoc />
    public IOrderSummaryBindableModel Create(AnnualPlanModel annualPlan)
    {
        return new OrderSummaryBindableModel(annualPlan);
    }
}