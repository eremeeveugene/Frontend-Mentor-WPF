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
using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageForms;
using FrontendMentor.MortgageRepaymentCalculator.Validators.MortgageForm;

namespace FrontendMentor.MortgageRepaymentCalculator.Tests.Validators;

[TestClass]
public sealed class MortgageFormValidatorTests
{
    private readonly MortgageFormValidator _validator = new();

    [TestMethod]
    public void Validate_ValidForm_ReadsTheMortgage()
    {
        var result = _validator.Validate(CreateForm("300,000", "25", "5.25", MortgageType.Repayment));

        Assert.IsEmpty(result.Errors);
        Assert.IsNotNull(result.Mortgage);
        Assert.AreEqual(300000m, result.Mortgage.Amount);
        Assert.AreEqual(25m, result.Mortgage.TermYears);
        Assert.AreEqual(5.25m, result.Mortgage.InterestRate);
        Assert.AreEqual(MortgageType.Repayment, result.Mortgage.Type);
    }

    [TestMethod]
    public void Validate_EmptyForm_RequiresEveryField()
    {
        var result = _validator.Validate(CreateForm(string.Empty, " ", string.Empty, null));

        Assert.AreEqual("The Mortgage Amount field is required.", result.Errors[nameof(MortgageFormModel.MortgageAmount)]);
        Assert.AreEqual("The Mortgage Term field is required.", result.Errors[nameof(MortgageFormModel.MortgageTerm)]);
        Assert.AreEqual("The Interest Rate field is required.", result.Errors[nameof(MortgageFormModel.InterestRate)]);
        Assert.AreEqual("The Mortgage Type field is required.", result.Errors[nameof(MortgageFormModel.MortgageType)]);
        Assert.IsNull(result.Mortgage);
    }

    [TestMethod]
    public void Validate_InvalidNumbers_ExplainsEachError()
    {
        var result = _validator.Validate(CreateForm("1.2.3", "0", "-1", MortgageType.InterestOnly));

        Assert.AreEqual("The Mortgage Amount field must be a number.", result.Errors[nameof(MortgageFormModel.MortgageAmount)]);
        Assert.AreEqual("The Mortgage Term field must be greater than zero.", result.Errors[nameof(MortgageFormModel.MortgageTerm)]);
        Assert.AreEqual("The Interest Rate field must not be negative.", result.Errors[nameof(MortgageFormModel.InterestRate)]);
        Assert.IsNull(result.Mortgage);
    }

    [TestMethod]
    public void Validate_ZeroInterestRate_IsValid()
    {
        var result = _validator.Validate(CreateForm("300000", "25", "0", MortgageType.Repayment));

        Assert.IsEmpty(result.Errors);
        Assert.AreEqual(0m, result.Mortgage!.InterestRate);
    }

    private static MortgageFormModel CreateForm(string amount, string term, string interestRate, MortgageType? type)
    {
        return new MortgageFormModel
        {
            MortgageAmount = amount,
            MortgageTerm = term,
            InterestRate = interestRate,
            MortgageType = type
        };
    }
}