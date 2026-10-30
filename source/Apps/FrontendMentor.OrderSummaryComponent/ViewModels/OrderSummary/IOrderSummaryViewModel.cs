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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.OrderSummaryComponent.BindableModels.OrderSummary;
using System.Windows.Input;

namespace FrontendMentor.OrderSummaryComponent.ViewModels.OrderSummary;

/// <summary>
///     The view model of the order summary.
/// </summary>
internal interface IOrderSummaryViewModel : IViewModel
{
    /// <summary>
    ///     Gets the command that proceeds to the payment.
    /// </summary>
    ICommand ProceedToPaymentCommand { get; }

    /// <summary>
    ///     Gets the command that cancels the order.
    /// </summary>
    ICommand CancelOrderCommand { get; }

    /// <summary>
    ///     Gets the command that changes the annual plan.
    /// </summary>
    ICommand ChangeAnnualPlanCommand { get; }

    /// <summary>
    ///     Gets the order summary that the view shows.
    /// </summary>
    IOrderSummaryBindableModel OrderSummary { get; }
}