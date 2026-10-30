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

using FrontendMentor.Core.Bindables;

namespace FrontendMentor.OrderSummaryComponent.BindableModels.OrderSummary;

/// <inheritdoc cref="IOrderSummaryBindableModel" />
internal sealed class OrderSummaryBindableModel : BindableBase, IOrderSummaryBindableModel
{
    public OrderSummaryBindableModel(OrderSummaryBindableModelParameters parameters)
    {
        var annualPlanPrice = parameters.AnnualPlanPrice;

        AnnualPlanPrice = annualPlanPrice;
    }

    /// <inheritdoc />
    public double AnnualPlanPrice { get; }
}