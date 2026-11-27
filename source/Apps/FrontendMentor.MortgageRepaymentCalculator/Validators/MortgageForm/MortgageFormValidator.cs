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
using FrontendMentor.MortgageRepaymentCalculator.Models.Mortgages;
using FrontendMentor.MortgageRepaymentCalculator.Properties;
using System.Globalization;

namespace FrontendMentor.MortgageRepaymentCalculator.Validators.MortgageForm;

/// <inheritdoc />
/// <remarks>
///     Every field is required. The amount and the term must be greater than zero, and the interest rate must not be
///     negative. Numbers are read with the invariant culture, so 300,000 and 5.25 are valid on every system.
/// </remarks>
internal sealed class MortgageFormValidator : IMortgageFormValidator
{
    /// <inheritdoc />
    public MortgageFormValidationModel Validate(MortgageFormModel mortgageForm)
    {
        var errors = new Dictionary<string, string>(StringComparer.Ordinal);

        var amount = ReadNumber(errors, nameof(MortgageFormModel.MortgageAmount), mortgageForm.MortgageAmount,
            Resources.MortgageRepaymentCalculatorView_MortgageAmountTextBlock_Text, false);
        var termYears = ReadNumber(errors, nameof(MortgageFormModel.MortgageTerm), mortgageForm.MortgageTerm,
            Resources.MortgageRepaymentCalculatorView_MortgageTermTextBlock_Text, false);
        var interestRate = ReadNumber(errors, nameof(MortgageFormModel.InterestRate), mortgageForm.InterestRate,
            Resources.MortgageRepaymentCalculatorView_InterestRateTextBlock_Text, true);

        if (mortgageForm.MortgageType == null)
        {
            errors[nameof(MortgageFormModel.MortgageType)] = FormatError(Resources.Validation_RequiredField_Error,
                Resources.MortgageRepaymentCalculatorView_MortgageTypeTextBlock_Text);
        }

        var mortgage = errors.Count == 0 && mortgageForm.MortgageType is { } mortgageType
            ? new MortgageModel { Amount = amount, TermYears = termYears, InterestRate = interestRate, Type = mortgageType }
            : null;

        var mortgageFormValidation = new MortgageFormValidationModel { Errors = errors, Mortgage = mortgage };

        return mortgageFormValidation;
    }

    /// <summary>
    ///     Reads a number from a field and records its error, if any.
    /// </summary>
    /// <param name="errors">The errors by field.</param>
    /// <param name="fieldKey">The key of the field in the errors.</param>
    /// <param name="text">The text of the field.</param>
    /// <param name="fieldName">The name of the field, which the error names.</param>
    /// <param name="allowZero">Whether zero is valid. Negative numbers are never valid.</param>
    /// <returns>The number, or zero when the field has an error.</returns>
    private static decimal ReadNumber(
        Dictionary<string, string> errors,
        string fieldKey,
        string text,
        string fieldName,
        bool allowZero)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            errors[fieldKey] = FormatError(Resources.Validation_RequiredField_Error, fieldName);

            return 0;
        }

        if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
        {
            errors[fieldKey] = FormatError(Resources.Validation_InvalidNumber_Error, fieldName);

            return 0;
        }

        if (value < 0 || (value == 0 && !allowZero))
        {
            errors[fieldKey] = FormatError(allowZero
                ? Resources.Validation_NegativeNumber_Error
                : Resources.Validation_NotPositiveNumber_Error, fieldName);

            return 0;
        }

        return value;
    }

    private static string FormatError(string format, string fieldName)
    {
        return string.Format(CultureInfo.CurrentCulture, format, fieldName);
    }
}