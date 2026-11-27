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

using FrontendMentor.Core.Bindables;
using FrontendMentor.Core.Commands;
using FrontendMentor.MortgageRepaymentCalculator.BindableModels.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Enums;
using FrontendMentor.MortgageRepaymentCalculator.Factories.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Models.Mortgages;
using FrontendMentor.MortgageRepaymentCalculator.Properties;
using FrontendMentor.MortgageRepaymentCalculator.Services.MortgageRepayments;
using System.Globalization;
using System.Windows.Input;

namespace FrontendMentor.MortgageRepaymentCalculator.ViewModels.MortgageRepaymentCalculator;

/// <inheritdoc cref="IMortgageRepaymentCalculatorViewModel" />
internal sealed class MortgageRepaymentCalculatorViewModel : BindableBase, IMortgageRepaymentCalculatorViewModel
{
    private readonly IMortgageRepaymentBindableModelFactory _mortgageRepaymentFactory;
    private readonly IMortgageRepaymentsService _mortgageRepaymentsService;

    public MortgageRepaymentCalculatorViewModel(
        IMortgageRepaymentBindableModelFactory mortgageRepaymentFactory,
        IMortgageRepaymentsService mortgageRepaymentsService)
    {
        _mortgageRepaymentFactory = mortgageRepaymentFactory;
        _mortgageRepaymentsService = mortgageRepaymentsService;
    }

    /// <inheritdoc />
    public ICommand CalculateRepaymentsCommand => field ??= new AsyncDelegateCommand(CalculateRepaymentsAsync);

    /// <inheritdoc />
    public ICommand ClearAllCommand => field ??= new DelegateCommand(ClearAll);

    /// <inheritdoc />
    public string MortgageAmount
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
            {
                MortgageAmountError = null;
            }
        }
    } = string.Empty;

    /// <inheritdoc />
    public string MortgageTerm
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
            {
                MortgageTermError = null;
            }
        }
    } = string.Empty;

    /// <inheritdoc />
    public string InterestRate
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
            {
                InterestRateError = null;
            }
        }
    } = string.Empty;

    /// <inheritdoc />
    public MortgageType? MortgageType
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
            {
                MortgageTypeError = null;
            }
        }
    }

    /// <inheritdoc />
    public string? MortgageAmountError
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public string? MortgageTermError
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public string? InterestRateError
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public string? MortgageTypeError
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public IMortgageRepaymentBindableModel? MortgageRepayment
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <summary>
    ///     Validates the form and, when it is valid, calculates the repayments.
    /// </summary>
    /// <returns>A task that completes when the repayments are calculated or the form is found invalid.</returns>
    private async Task CalculateRepaymentsAsync()
    {
        MortgageAmountError = ValidateNumber(MortgageAmount,
            Resources.MortgageRepaymentCalculatorView_MortgageAmountTextBlock_Text, false, out var amount);
        MortgageTermError = ValidateNumber(MortgageTerm,
            Resources.MortgageRepaymentCalculatorView_MortgageTermTextBlock_Text, false, out var termYears);
        InterestRateError = ValidateNumber(InterestRate,
            Resources.MortgageRepaymentCalculatorView_InterestRateTextBlock_Text, true, out var interestRate);
        MortgageTypeError = MortgageType == null
            ? FormatError(Resources.Validation_RequiredField_Error,
                Resources.MortgageRepaymentCalculatorView_MortgageTypeTextBlock_Text)
            : null;

        if (MortgageAmountError != null || MortgageTermError != null || InterestRateError != null ||
            MortgageType is not { } mortgageType)
        {
            MortgageRepayment = null;

            return;
        }

        var mortgage = new MortgageModel
        {
            Amount = amount,
            TermYears = termYears,
            InterestRate = interestRate,
            Type = mortgageType
        };

        var mortgageRepayment = await _mortgageRepaymentsService.GetMortgageRepaymentAsync(mortgage);

        MortgageRepayment = _mortgageRepaymentFactory.Create(mortgageRepayment);
    }

    /// <summary>
    ///     Clears the form, its errors and the repayments.
    /// </summary>
    private void ClearAll()
    {
        MortgageAmount = string.Empty;
        MortgageTerm = string.Empty;
        InterestRate = string.Empty;
        MortgageType = null;
        MortgageAmountError = null;
        MortgageTermError = null;
        InterestRateError = null;
        MortgageTypeError = null;
        MortgageRepayment = null;
    }

    /// <summary>
    ///     Validates a number that was entered in a field.
    /// </summary>
    /// <param name="text">The text of the field. Thousands separators are allowed, such as in 300,000.</param>
    /// <param name="fieldName">The name of the field, which the error names.</param>
    /// <param name="allowZero">Whether zero is valid. Negative numbers are never valid.</param>
    /// <param name="value">The number, when it is valid.</param>
    /// <returns>The error, or <c>null</c> when the number is valid.</returns>
    private static string? ValidateNumber(string text, string fieldName, bool allowZero, out decimal value)
    {
        value = 0;

        if (string.IsNullOrWhiteSpace(text))
        {
            return FormatError(Resources.Validation_RequiredField_Error, fieldName);
        }

        if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
        {
            return FormatError(Resources.Validation_InvalidNumber_Error, fieldName);
        }

        if (value < 0 || (value == 0 && !allowZero))
        {
            return FormatError(allowZero
                ? Resources.Validation_NegativeNumber_Error
                : Resources.Validation_NotPositiveNumber_Error, fieldName);
        }

        return null;
    }

    /// <summary>
    ///     Formats an error that names its field.
    /// </summary>
    /// <param name="format">The format of the error.</param>
    /// <param name="fieldName">The name of the field.</param>
    /// <returns>The error.</returns>
    private static string FormatError(string format, string fieldName)
    {
        return string.Format(CultureInfo.CurrentCulture, format, fieldName);
    }
}