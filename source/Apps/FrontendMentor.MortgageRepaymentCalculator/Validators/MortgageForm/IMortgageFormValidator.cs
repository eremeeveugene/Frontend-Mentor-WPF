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

using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageForms;
using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageFormValidations;

namespace FrontendMentor.MortgageRepaymentCalculator.Validators.MortgageForm;

/// <summary>
///     Validates the mortgage form.
/// </summary>
internal interface IMortgageFormValidator
{
    /// <summary>
    ///     Validates the values of the mortgage form and reads the mortgage from them.
    /// </summary>
    /// <param name="mortgageForm">The values of the form, as entered.</param>
    /// <returns>The errors by field, and the mortgage when the form has no errors.</returns>
    MortgageFormValidationModel Validate(MortgageFormModel mortgageForm);
}