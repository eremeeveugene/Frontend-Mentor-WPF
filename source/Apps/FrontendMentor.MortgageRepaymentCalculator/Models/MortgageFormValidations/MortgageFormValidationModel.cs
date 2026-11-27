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

using FrontendMentor.MortgageRepaymentCalculator.Models.Mortgages;

namespace FrontendMentor.MortgageRepaymentCalculator.Models.MortgageFormValidations;

/// <summary>
///     The result of the validation of the mortgage form.
/// </summary>
internal sealed class MortgageFormValidationModel
{
    /// <summary>
    ///     Gets or initializes the errors by the name of the field in <see cref="MortgageForms.MortgageFormModel" />.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Errors { get; init; }

    /// <summary>
    ///     Gets or initializes the mortgage that the form describes, or <c>null</c> when the form has errors.
    /// </summary>
    public required MortgageModel? Mortgage { get; init; }
}