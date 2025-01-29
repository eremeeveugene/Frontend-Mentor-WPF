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
using System.Windows.Input;

namespace FrontendMentor.OrderSummaryComponent.ViewModels;

internal sealed class OrderSummaryComponentViewModel(
    IContainerProvider containerProvider)
    : NavigationViewModelBase
{
    private ICommand? _cancelOrderCommand;
    private ICommand? _changeAnnualPlanCommand;

    private double _price;
    private ICommand? _proceedToPaymentCommand;

    public double Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public ICommand ProceedToPaymentCommand => _proceedToPaymentCommand ??= new DelegateCommand(ProceedToPayment);

    public ICommand CancelOrderCommand => _cancelOrderCommand ??= new DelegateCommand(CancelOrder);

    public ICommand ChangeAnnualPlanCommand => _changeAnnualPlanCommand ??= new DelegateCommand(ChangeAnnualPlan);
    //private ResultSummaryBindableModel? _resultSummary;

    //public ResultSummaryBindableModel? ResultSummary
    //{
    //    get => _resultSummary;
    //    private set => SetProperty(ref _resultSummary, value);
    //}

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        //var resultSummary = resultSummaryService.GetResultSummary();

        //ResultSummary = ResultSummaryBindableModel.Create(containerProvider,
        //    new ResultSummaryBindableModel.Parameters(resultSummary));

        Price = 59.99;
    }

    private void ChangeAnnualPlan()
    {
        // Implement logic to change the annual plan
    }

    private void ProceedToPayment()
    {
        // Implement payment processing logic
    }

    private void CancelOrder()
    {
        // Implement order cancellation logic
    }
}