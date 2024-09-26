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

    public ICommand CalculateCommand => _calculateCommand ??= new DelegateCommand(Calculate);

    public MortgageRepaymentCalculatorBindableModel MortgageRepaymentCalculator { get; } = new();

    private void Calculate()
    {
        throw new NotImplementedException();
    }
}