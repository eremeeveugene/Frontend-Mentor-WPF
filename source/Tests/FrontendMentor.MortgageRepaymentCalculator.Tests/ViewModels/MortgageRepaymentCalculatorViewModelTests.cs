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
using FrontendMentor.MortgageRepaymentCalculator.Validators.MortgageForm;
using FrontendMentor.MortgageRepaymentCalculator.ViewModels.MortgageRepaymentCalculator;

namespace FrontendMentor.MortgageRepaymentCalculator.Tests.ViewModels;

[TestClass]
public sealed class MortgageRepaymentCalculatorViewModelTests
{
    private List<string?> _changedErrors = null!;
    private MortgageRepaymentCalculatorViewModel _viewModel = null!;

    [TestInitialize]
    public void Initialize()
    {
        _viewModel = new MortgageRepaymentCalculatorViewModel(new MortgageRepaymentBindableModelFactory(),
            new MortgageRepaymentsService(), new MortgageFormValidator());
        _changedErrors = [];
        _viewModel.ErrorsChanged += (_, e) => _changedErrors.Add(e.PropertyName);
    }

    [TestMethod]
    public async Task CalculateRepaymentsCommand_ValidForm_ShowsTheRepayments()
    {
        FillForm();

        await CalculateAsync();

        Assert.IsFalse(_viewModel.HasErrors);
        Assert.IsNotNull(_viewModel.MortgageRepayment);
        Assert.AreEqual(1797.74m, _viewModel.MortgageRepayment.MonthlyRepayment);
        Assert.AreEqual(539322.94m, _viewModel.MortgageRepayment.TotalRepayment);
    }

    [TestMethod]
    public async Task CalculateRepaymentsCommand_EmptyForm_ReportsAnErrorForEveryField()
    {
        await CalculateAsync();

        Assert.IsTrue(_viewModel.HasErrors);
        Assert.AreEqual("The Mortgage Amount field is required.", GetError(nameof(_viewModel.MortgageAmount)));
        Assert.AreEqual("The Mortgage Type field is required.", GetError(nameof(_viewModel.MortgageType)));
        CollectionAssert.AreEquivalent(
            new[] { nameof(_viewModel.MortgageAmount), nameof(_viewModel.MortgageTerm), nameof(_viewModel.InterestRate), nameof(_viewModel.MortgageType) },
            _changedErrors);
        Assert.IsNull(_viewModel.MortgageRepayment);
    }

    [TestMethod]
    public async Task EditingAField_ClearsOnlyItsError()
    {
        await CalculateAsync();

        _viewModel.MortgageAmount = "300000";
        _viewModel.MortgageType = MortgageType.InterestOnly;

        Assert.IsNull(GetError(nameof(_viewModel.MortgageAmount)));
        Assert.IsNull(GetError(nameof(_viewModel.MortgageType)));
        Assert.IsNotNull(GetError(nameof(_viewModel.MortgageTerm)));
    }

    [TestMethod]
    public async Task CalculateRepaymentsCommand_InvalidFormAfterAResult_ClearsTheResult()
    {
        FillForm();
        await CalculateAsync();

        _viewModel.MortgageTerm = string.Empty;
        await CalculateAsync();

        Assert.IsNull(_viewModel.MortgageRepayment);
        Assert.AreEqual("The Mortgage Term field is required.", GetError(nameof(_viewModel.MortgageTerm)));
    }

    [TestMethod]
    public async Task ClearAllCommand_ClearsTheFormTheErrorsAndTheResult()
    {
        await CalculateAsync();
        FillForm();
        _viewModel.MortgageTerm = string.Empty;
        await CalculateAsync();

        _viewModel.ClearAllCommand.Execute(null);

        Assert.AreEqual(string.Empty, _viewModel.MortgageAmount);
        Assert.AreEqual(string.Empty, _viewModel.MortgageTerm);
        Assert.AreEqual(string.Empty, _viewModel.InterestRate);
        Assert.IsNull(_viewModel.MortgageType);
        Assert.IsFalse(_viewModel.HasErrors);
        Assert.IsNull(_viewModel.MortgageRepayment);
    }

    private string? GetError(string propertyName)
    {
        foreach (var error in _viewModel.GetErrors(propertyName))
        {
            return (string)error;
        }

        return null;
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