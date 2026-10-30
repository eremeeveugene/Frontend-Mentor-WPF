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
using FrontendMentor.Core.Commands;
using FrontendMentor.OrderSummaryComponent.BindableModels.OrderSummary;
using FrontendMentor.OrderSummaryComponent.Services.AnnualPlan;
using System.Windows.Input;

namespace FrontendMentor.OrderSummaryComponent.ViewModels.OrderSummary;

/// <inheritdoc cref="IOrderSummaryViewModel" />
internal sealed class OrderSummaryViewModel : BindableBase, IOrderSummaryViewModel
{

    public OrderSummaryViewModel(
        Func<OrderSummaryBindableModelParameters, IOrderSummaryBindableModel> orderSummaryFactory,
        IAnnualPlanService annualPlanService)
    {
        OrderSummary = orderSummaryFactory(new OrderSummaryBindableModelParameters(annualPlanService.GetAnnualPlanPrice()));
    }

    /// <inheritdoc />
    public ICommand ProceedToPaymentCommand => field ??= new DelegateCommand(ProceedToPayment);

    /// <inheritdoc />
    public ICommand CancelOrderCommand => field ??= new DelegateCommand(CancelOrder);

    /// <inheritdoc />
    public ICommand ChangeAnnualPlanCommand => field ??= new DelegateCommand(ChangeAnnualPlan);

    /// <inheritdoc />
    public IOrderSummaryBindableModel OrderSummary { get; }

    /// <summary>
    ///     Changes the annual plan.
    /// </summary>
    private void ChangeAnnualPlan()
    {
        // Implement logic to change the annual plan
    }

    /// <summary>
    ///     Proceeds to the payment.
    /// </summary>
    private void ProceedToPayment()
    {
        // Implement payment processing logic
    }

    /// <summary>
    ///     Cancels the order.
    /// </summary>
    private void CancelOrder()
    {
        // Implement order cancellation logic
    }
}