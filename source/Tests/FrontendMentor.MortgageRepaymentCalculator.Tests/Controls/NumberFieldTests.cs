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

using FrontendMentor.MortgageRepaymentCalculator.Controls.NumberFields;

namespace FrontendMentor.MortgageRepaymentCalculator.Tests.Controls;

[TestClass]
public sealed class NumberFieldTests
{
    [TestMethod]
    [DataRow("7")]
    [DataRow("300,000")]
    [DataRow("5.25")]
    public void IsNumberText_DigitsAndSeparators_IsTrue(string text)
    {
        Assert.IsTrue(NumberField.IsNumberText(text));
    }

    [TestMethod]
    [DataRow("a")]
    [DataRow("-")]
    [DataRow(" ")]
    [DataRow("٣")]
    public void IsNumberText_OtherCharacters_IsFalse(string text)
    {
        Assert.IsFalse(NumberField.IsNumberText(text));
    }

    [STATestMethod]
    public void Error_SetsHasError()
    {
        var numberField = new NumberField { Error = "The Mortgage Term field is required." };

        Assert.IsTrue(numberField.HasError);

        numberField.Error = null;

        Assert.IsFalse(numberField.HasError);
    }
}