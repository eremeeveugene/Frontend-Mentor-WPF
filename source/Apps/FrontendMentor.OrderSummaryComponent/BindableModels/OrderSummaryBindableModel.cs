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

namespace FrontendMentor.OrderSummaryComponent.BindableModels;

internal sealed class OrderSummaryBindableModel(OrderSummaryBindableModel.Parameters parameters)
    : BindableBase
{
    public double AnnualPlanPrice
    {
        get;
    } = parameters.AnnualPlanPrice;

    public static OrderSummaryBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<OrderSummaryBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(double AnnualPlanPrice);
}