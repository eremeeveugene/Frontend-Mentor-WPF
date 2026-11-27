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
using FrontendMentor.MortgageRepaymentCalculator.Models.Mortgages;
using FrontendMentor.MortgageRepaymentCalculator.Services.MortgageRepayments;

namespace FrontendMentor.MortgageRepaymentCalculator.Tests.Services;

[TestClass]
public sealed class MortgageRepaymentsServiceTests
{
    private readonly MortgageRepaymentsService _service = new();

    [TestMethod]
    public async Task GetMortgageRepaymentAsync_Repayment_MatchesTheDesign()
    {
        var mortgageRepayment = await _service.GetMortgageRepaymentAsync(CreateMortgage(MortgageType.Repayment, 5.25m));

        Assert.AreEqual(1797.74m, mortgageRepayment.MonthlyRepayment);
        Assert.AreEqual(539322.94m, mortgageRepayment.TotalRepayment);
    }

    [TestMethod]
    public async Task GetMortgageRepaymentAsync_InterestOnly_RepaysOnlyTheInterest()
    {
        var mortgageRepayment = await _service.GetMortgageRepaymentAsync(CreateMortgage(MortgageType.InterestOnly, 5.25m));

        Assert.AreEqual(1312.50m, mortgageRepayment.MonthlyRepayment);
        Assert.AreEqual(393750.00m, mortgageRepayment.TotalRepayment);
    }

    [TestMethod]
    public async Task GetMortgageRepaymentAsync_RepaymentWithoutInterest_SplitsTheAmountOverTheTerm()
    {
        var mortgageRepayment = await _service.GetMortgageRepaymentAsync(CreateMortgage(MortgageType.Repayment, 0));

        Assert.AreEqual(1000m, mortgageRepayment.MonthlyRepayment);
        Assert.AreEqual(300000m, mortgageRepayment.TotalRepayment);
    }

    [TestMethod]
    public async Task GetMortgageRepaymentAsync_CanceledToken_Throws()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        await cancellationTokenSource.CancelAsync();

        await Assert.ThrowsAsync<OperationCanceledException>(() =>
            _service.GetMortgageRepaymentAsync(CreateMortgage(MortgageType.Repayment, 5.25m), cancellationTokenSource.Token));
    }

    private static MortgageModel CreateMortgage(MortgageType type, decimal interestRate)
    {
        return new MortgageModel
        {
            Amount = 300000,
            TermYears = 25,
            InterestRate = interestRate,
            Type = type
        };
    }
}