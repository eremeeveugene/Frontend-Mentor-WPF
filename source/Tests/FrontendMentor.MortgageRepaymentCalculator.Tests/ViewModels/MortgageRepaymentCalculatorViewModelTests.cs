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
using FrontendMentor.MortgageRepaymentCalculator.Factories.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Services.MortgageRepayments;
using FrontendMentor.MortgageRepaymentCalculator.ViewModels.MortgageRepaymentCalculator;

namespace FrontendMentor.MortgageRepaymentCalculator.Tests.ViewModels;

[TestClass]
public sealed class MortgageRepaymentCalculatorViewModelTests
{
    private MortgageRepaymentCalculatorViewModel _viewModel = null!;

    [TestInitialize]
    public void Initialize()
    {
        _viewModel = new MortgageRepaymentCalculatorViewModel(new MortgageRepaymentBindableModelFactory(),
            new MortgageRepaymentsService());
    }

    [TestMethod]
    public async Task CalculateRepaymentsCommand_ValidForm_ShowsTheRepayments()
    {
        FillForm();

        await CalculateAsync();

        Assert.IsNotNull(_viewModel.MortgageRepayment);
        Assert.AreEqual(1797.74m, _viewModel.MortgageRepayment.MonthlyRepayment);
        Assert.AreEqual(539322.94m, _viewModel.MortgageRepayment.TotalRepayment);
    }

    [TestMethod]
    public async Task CalculateRepaymentsCommand_EmptyForm_RequiresEveryField()
    {
        await CalculateAsync();

        Assert.AreEqual("The Mortgage Amount field is required.", _viewModel.MortgageAmountError);
        Assert.AreEqual("The Mortgage Term field is required.", _viewModel.MortgageTermError);
        Assert.AreEqual("The Interest Rate field is required.", _viewModel.InterestRateError);
        Assert.AreEqual("The Mortgage Type field is required.", _viewModel.MortgageTypeError);
        Assert.IsNull(_viewModel.MortgageRepayment);
    }

    [TestMethod]
    public async Task CalculateRepaymentsCommand_InvalidNumbers_ExplainsTheError()
    {
        FillForm();
        _viewModel.MortgageAmount = "1.2.3";
        _viewModel.MortgageTerm = "0";
        _viewModel.InterestRate = "0";

        await CalculateAsync();

        Assert.AreEqual("The Mortgage Amount field must be a number.", _viewModel.MortgageAmountError);
        Assert.AreEqual("The Mortgage Term field must be greater than zero.", _viewModel.MortgageTermError);
        Assert.IsNull(_viewModel.InterestRateError, "An interest rate of zero is valid.");
    }

    [TestMethod]
    public async Task EditingAField_ClearsItsError()
    {
        await CalculateAsync();

        _viewModel.MortgageAmount = "300000";
        _viewModel.MortgageType = MortgageType.InterestOnly;

        Assert.IsNull(_viewModel.MortgageAmountError);
        Assert.IsNull(_viewModel.MortgageTypeError);
        Assert.IsNotNull(_viewModel.MortgageTermError, "Only the edited field is cleared.");
    }

    [TestMethod]
    public async Task CalculateRepaymentsCommand_InvalidFormAfterAResult_ClearsTheResult()
    {
        FillForm();
        await CalculateAsync();

        _viewModel.MortgageTerm = string.Empty;
        await CalculateAsync();

        Assert.IsNull(_viewModel.MortgageRepayment);
    }

    [TestMethod]
    public async Task ClearAllCommand_ClearsTheFormTheErrorsAndTheResult()
    {
        FillForm();
        await CalculateAsync();
        _viewModel.MortgageTerm = string.Empty;
        await CalculateAsync();
        FillForm();
        await CalculateAsync();

        _viewModel.ClearAllCommand.Execute(null);

        Assert.AreEqual(string.Empty, _viewModel.MortgageAmount);
        Assert.AreEqual(string.Empty, _viewModel.MortgageTerm);
        Assert.AreEqual(string.Empty, _viewModel.InterestRate);
        Assert.IsNull(_viewModel.MortgageType);
        Assert.IsNull(_viewModel.MortgageTermError);
        Assert.IsNull(_viewModel.MortgageRepayment);
    }

    private void FillForm()
    {
        _viewModel.MortgageAmount = "300,000";
        _viewModel.MortgageTerm = "25";
        _viewModel.InterestRate = "5.25";
        _viewModel.MortgageType = MortgageType.Repayment;
    }

    private async Task CalculateAsync()
    {
        _viewModel.CalculateRepaymentsCommand.Execute(null);

        for (var i = 0; i < 100 && !_viewModel.CalculateRepaymentsCommand.CanExecute(null); i++)
        {
            await Task.Delay(10);
        }
    }
}