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
using FrontendMentor.MortgageRepaymentCalculator.BindableModels.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Enums;
using System.Windows.Input;

namespace FrontendMentor.MortgageRepaymentCalculator.ViewModels.MortgageRepaymentCalculator;

/// <summary>
///     The view model of the mortgage repayment calculator.
/// </summary>
internal interface IMortgageRepaymentCalculatorViewModel : IViewModel
{
    /// <summary>
    ///     Gets the command that validates the form and calculates the repayments.
    /// </summary>
    ICommand CalculateRepaymentsCommand { get; }

    /// <summary>
    ///     Gets the command that clears the form and the repayments.
    /// </summary>
    ICommand ClearAllCommand { get; }

    /// <summary>
    ///     Gets or sets the amount that is borrowed, as entered.
    /// </summary>
    string MortgageAmount { get; set; }

    /// <summary>
    ///     Gets or sets the term in years, as entered.
    /// </summary>
    string MortgageTerm { get; set; }

    /// <summary>
    ///     Gets or sets the annual interest rate in percent, as entered.
    /// </summary>
    string InterestRate { get; set; }

    /// <summary>
    ///     Gets or sets the type of the mortgage, or <c>null</c> when none is chosen.
    /// </summary>
    MortgageType? MortgageType { get; set; }

    /// <summary>
    ///     Gets the error of the mortgage amount, or <c>null</c> when it is valid.
    /// </summary>
    string? MortgageAmountError { get; }

    /// <summary>
    ///     Gets the error of the mortgage term, or <c>null</c> when it is valid.
    /// </summary>
    string? MortgageTermError { get; }

    /// <summary>
    ///     Gets the error of the interest rate, or <c>null</c> when it is valid.
    /// </summary>
    string? InterestRateError { get; }

    /// <summary>
    ///     Gets the error of the mortgage type, or <c>null</c> when it is valid.
    /// </summary>
    string? MortgageTypeError { get; }

    /// <summary>
    ///     Gets the repayments of the last calculation, or <c>null</c> until the repayments are calculated.
    /// </summary>
    IMortgageRepaymentBindableModel? MortgageRepayment { get; }
}