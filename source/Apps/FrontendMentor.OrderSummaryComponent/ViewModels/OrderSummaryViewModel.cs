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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.OrderSummaryComponent.BindableModels;
using FrontendMentor.OrderSummaryComponent.Services.AnnualPlan;
using System.Windows.Input;

namespace FrontendMentor.OrderSummaryComponent.ViewModels;

internal sealed class OrderSummaryViewModel(
    IContainerProvider containerProvider,
    IAnnualPlanService annualPlanService)
    : NavigationViewModelBase
{
    private ICommand? _cancelOrderCommand;
    private ICommand? _changeAnnualPlanCommand;
    private OrderSummaryBindableModel _orderSummary = null!;
    private ICommand? _proceedToPaymentCommand;
    public ICommand ProceedToPaymentCommand => _proceedToPaymentCommand ??= new DelegateCommand(ProceedToPayment);
    public ICommand CancelOrderCommand => _cancelOrderCommand ??= new DelegateCommand(CancelOrder);
    public ICommand ChangeAnnualPlanCommand => _changeAnnualPlanCommand ??= new DelegateCommand(ChangeAnnualPlan);

    public OrderSummaryBindableModel OrderSummary
    {
        get => _orderSummary;
        private set => SetProperty(ref _orderSummary, value);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        var annualPlanPrice = annualPlanService.GetAnnualPlanPrice();

        OrderSummary = OrderSummaryBindableModel.Create(containerProvider,
            new OrderSummaryBindableModel.Parameters(annualPlanPrice));
    }

    private void ChangeAnnualPlan()
    {
        // Implement change annual plan functionality
    }

    private void ProceedToPayment()
    {
        // Implement payment processing functionality
    }

    private void CancelOrder()
    {
        // Implement order cancellation functionality
    }
}