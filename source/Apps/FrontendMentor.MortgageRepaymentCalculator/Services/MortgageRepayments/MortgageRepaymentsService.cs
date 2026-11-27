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

using FrontendMentor.MortgageRepaymentCalculator.Enums;
using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageRepayments;
using FrontendMentor.MortgageRepaymentCalculator.Models.Mortgages;

namespace FrontendMentor.MortgageRepaymentCalculator.Services.MortgageRepayments;

/// <inheritdoc />
internal sealed class MortgageRepaymentsService : IMortgageRepaymentsService
{
    private const int MonthsPerYear = 12;

    /// <inheritdoc />
    public Task<MortgageRepaymentModel> GetMortgageRepaymentAsync(
        MortgageModel mortgage,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var months = mortgage.TermYears * MonthsPerYear;
        var monthlyRate = mortgage.InterestRate / 100 / MonthsPerYear;
        var monthlyRepayment = mortgage.Type == MortgageType.InterestOnly
            ? mortgage.Amount * monthlyRate
            : GetAnnuity(mortgage.Amount, monthlyRate, months);

        var mortgageRepayment = new MortgageRepaymentModel
        {
            MonthlyRepayment = Math.Round(monthlyRepayment, 2, MidpointRounding.AwayFromZero),
            TotalRepayment = Math.Round(monthlyRepayment * months, 2, MidpointRounding.AwayFromZero)
        };

        return Task.FromResult(mortgageRepayment);
    }

    /// <summary>
    ///     Calculates the monthly repayment that pays back the amount and the interest over the term.
    /// </summary>
    /// <param name="amount">The amount that is borrowed.</param>
    /// <param name="monthlyRate">The interest rate per month as a fraction.</param>
    /// <param name="months">The term in months.</param>
    /// <returns>The monthly repayment.</returns>
    private static decimal GetAnnuity(decimal amount, decimal monthlyRate, decimal months)
    {
        if (monthlyRate == 0)
        {
            return amount / months;
        }

        var growth = (decimal)Math.Pow(1 + (double)monthlyRate, (double)months);

        return amount * monthlyRate * growth / (growth - 1);
    }
}