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

namespace FrontendMentor.MortgageRepaymentCalculator.Models.Mortgages;

/// <summary>
///     The data of a mortgage.
/// </summary>
internal sealed class MortgageModel
{
    /// <summary>
    ///     Gets or initializes the amount that is borrowed.
    /// </summary>
    public required decimal Amount { get; init; }

    /// <summary>
    ///     Gets or initializes the term in years.
    /// </summary>
    public required decimal TermYears { get; init; }

    /// <summary>
    ///     Gets or initializes the annual interest rate in percent.
    /// </summary>
    public required decimal InterestRate { get; init; }

    /// <summary>
    ///     Gets or initializes the type of the mortgage.
    /// </summary>
    public required MortgageType Type { get; init; }
}