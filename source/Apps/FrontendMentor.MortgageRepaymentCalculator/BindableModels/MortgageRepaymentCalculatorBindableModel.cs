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

using FrontendMentor.MortgageRepaymentCalculator.Enums;

namespace FrontendMentor.MortgageRepaymentCalculator.BindableModels;

internal sealed class MortgageRepaymentCalculatorBindableModel : BindableBase
{
    private double _amount;
    private double _rate;
    private MortgageTypeBindableModel? _selectedMortgageType;
    private int _term;

    public MortgageRepaymentCalculatorBindableModel()
    {
        SelectedMortgageType = MortgageTypes.FirstOrDefault();
    }

    public double Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    public int Term
    {
        get => _term;
        set => SetProperty(ref _term, value);
    }

    public double InterestRate
    {
        get => _rate;
        set => SetProperty(ref _rate, value);
    }

    public MortgageTypeBindableModel? SelectedMortgageType
    {
        get => _selectedMortgageType;
        set => SetProperty(ref _selectedMortgageType, value);
    }

    public List<MortgageTypeBindableModel> MortgageTypes { get; } = GetMortgageTypes();


    public double CalculateMonthlyPayment()
    {
        var termMonths = Term * 12;
        var monthlyInterestRate = InterestRate / 100 / 12;
        double monthlyPayment;

        if (SelectedMortgageType == null)
        {
            throw new InvalidOperationException();
        }

        if (SelectedMortgageType.MortgageType == MortgageType.Repayment)
        {
            monthlyPayment = Amount * monthlyInterestRate /
                             (1 - Math.Pow(1 + monthlyInterestRate, -termMonths));
        }
        else if (SelectedMortgageType.MortgageType == MortgageType.InterestOnly)
        {
            monthlyPayment = Amount * monthlyInterestRate;
        }
        else
        {
            throw new ArgumentException("Invalid loan type. Choose 'repayment' or 'interest only'.");
        }

        return monthlyPayment;
    }

    public double CalculateTotalRepayment()
    {
        var termMonths = Term * 12;
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
            totalRepayment = (monthlyPayment * termMonths) + Amount;
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