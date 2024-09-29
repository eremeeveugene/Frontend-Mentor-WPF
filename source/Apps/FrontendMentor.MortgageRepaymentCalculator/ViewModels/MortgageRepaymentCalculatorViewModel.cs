// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Core.ViewModels;
using FrontendMentor.MortgageRepaymentCalculator.BindableModels;
using System.Windows.Input;

namespace FrontendMentor.MortgageRepaymentCalculator.ViewModels;

internal sealed class MortgageRepaymentCalculatorViewModel : NavigationViewModelBase
{
    private ICommand? _calculateCommand;
    private ICommand? _clearCommand;
    private bool _isCalculated;
    private double _monthlyPayment;
    private double _totalRepayment;

    public ICommand CalculateCommand => _calculateCommand ??= new DelegateCommand(Calculate);
    public ICommand ClearCommand => _clearCommand ??= new DelegateCommand(Clear);

    public MortgageRepaymentCalculatorBindableModel MortgageRepaymentCalculator { get; } = new();

    public bool IsCalculated
    {
        get => _isCalculated;
        private set => SetProperty(ref _isCalculated, value);
    }

    public double MonthlyPayment
    {
        get => _monthlyPayment;
        private set => SetProperty(ref _monthlyPayment, value);
    }

    public double TotalRepayment
    {
        get => _totalRepayment;
        private set => SetProperty(ref _totalRepayment, value);
    }

    private void Clear()
    {
        MortgageRepaymentCalculator.Reset();

        IsCalculated = false;
    }

    private void Calculate()
    {
        if (!MortgageRepaymentCalculator.Validate())
        {
            IsCalculated = false;

            return;
        }

        MonthlyPayment = MortgageRepaymentCalculator.CalculateMonthlyPayment();
        TotalRepayment = MortgageRepaymentCalculator.CalculateTotalRepayment();

        IsCalculated = true;
    }
}