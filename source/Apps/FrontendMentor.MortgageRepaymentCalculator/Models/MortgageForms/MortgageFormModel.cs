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

namespace FrontendMentor.MortgageRepaymentCalculator.Models.MortgageForms;

/// <summary>
///     The values of the mortgage form, as entered.
/// </summary>
internal sealed class MortgageFormModel
{
    /// <summary>
    ///     Gets or initializes the amount that is borrowed, as entered.
    /// </summary>
    public required string MortgageAmount { get; init; }

    /// <summary>
    ///     Gets or initializes the term in years, as entered.
    /// </summary>
    public required string MortgageTerm { get; init; }

    /// <summary>
    ///     Gets or initializes the annual interest rate in percent, as entered.
    /// </summary>
    public required string InterestRate { get; init; }

    /// <summary>
    ///     Gets or initializes the type of the mortgage, or <c>null</c> when none is chosen.
    /// </summary>
    public required MortgageType? MortgageType { get; init; }
}