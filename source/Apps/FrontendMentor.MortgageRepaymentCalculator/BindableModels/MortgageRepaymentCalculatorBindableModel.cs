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

using FrontendMentor.Core.Attributes;
using FrontendMentor.Core.BindableModels;
using FrontendMentor.MortgageRepaymentCalculator.Enums;
using System.ComponentModel.DataAnnotations;

namespace FrontendMentor.MortgageRepaymentCalculator.BindableModels;

internal sealed class MortgageRepaymentCalculatorBindableModel : ValidatableModelBase
{
    private double? _mortgageAmount;
    private double? _mortgageRate;
    private MortgageTypeBindableModel? _selectedMortgageType;
    private int? _term;

    [Required]
    [Range(50000.0, 1000000.0)]
    [Resettable]
    [Display(Name = "Mortgage Amount")]
    public double? MortgageAmount
    {
        get => _mortgageAmount;
        set => SetValidatedProperty(ref _mortgageAmount, value);
    }

    [Required]
    [Range(5, 30)]
    [Resettable]
    [Display(Name = "Mortgage Term")]
    public int? MortgageTerm
    {
        get => _term;
        set => SetValidatedProperty(ref _term, value);
    }

    [Required]
    [Range(1.0, 10.0)]
    [Resettable]
    [Display(Name = "Interest Rate")]
    public double? InterestRate
    {
        get => _mortgageRate;
        set => SetValidatedProperty(ref _mortgageRate, value);
    }
    [Required]
    [Resettable]
    [Display(Name = "Mortgage Type")]
    public MortgageTypeBindableModel? SelectedMortgageType
    {
        get => _selectedMortgageType;
        set => SetValidatedProperty(ref _selectedMortgageType, value);
    }

    public List<MortgageTypeBindableModel> MortgageTypes { get; } = GetMortgageTypes();

    public double CalculateMonthlyPayment()
    {
        var termMonths = MortgageTerm.Value * 12;
        var monthlyInterestRate = InterestRate.Value / 100 / 12;
        double monthlyPayment;

        if (SelectedMortgageType == null)
        {
            throw new InvalidOperationException();
        }

        if (SelectedMortgageType.MortgageType == MortgageType.Repayment)
        {
            monthlyPayment = MortgageAmount.Value * monthlyInterestRate /
                             (1 - Math.Pow(1 + monthlyInterestRate, -termMonths));
        }
        else if (SelectedMortgageType.MortgageType == MortgageType.InterestOnly)
        {
            monthlyPayment = MortgageAmount.Value * monthlyInterestRate;
        }
        else
        {
            throw new ArgumentException("Invalid loan type. Choose 'repayment' or 'interest only'.");
        }

        return monthlyPayment;
    }

    public double CalculateTotalRepayment()
    {
        var termMonths = MortgageTerm.Value * 12;
        var monthlyPayment = CalculateMonthlyPayment();
        double totalRepayment;

        if (SelectedMortgageType == null)
        {
            throw new InvalidOperationException();
        }

        if (SelectedMortgageType.MortgageType == MortgageType.Repayment)
        {
            totalRepayment = monthlyPayment * termMonths;
        }
        else if (SelectedMortgageType.MortgageType == MortgageType.InterestOnly)
        {
            totalRepayment = (monthlyPayment * termMonths) + MortgageAmount.Value;
        }
        else
        {
            throw new ArgumentException("Invalid loan type. Choose 'repayment' or 'interest only'.");
        }

        return totalRepayment;
    }

    private static List<MortgageTypeBindableModel> GetMortgageTypes()
    {
        return Enum.GetValues<MortgageType>().Select(mortgageType =>
            new MortgageTypeBindableModel(new MortgageTypeBindableModel.Parameters(mortgageType))).ToList();
    }
}