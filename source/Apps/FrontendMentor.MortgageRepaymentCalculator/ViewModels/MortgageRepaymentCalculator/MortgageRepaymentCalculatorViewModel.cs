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
using FrontendMentor.Core.DataErrors;
using FrontendMentor.MortgageRepaymentCalculator.BindableModels.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Enums;
using FrontendMentor.MortgageRepaymentCalculator.Factories.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageForms;
using FrontendMentor.MortgageRepaymentCalculator.Services.MortgageRepayments;
using FrontendMentor.MortgageRepaymentCalculator.Validators.MortgageForm;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace FrontendMentor.MortgageRepaymentCalculator.ViewModels.MortgageRepaymentCalculator;

/// <inheritdoc cref="IMortgageRepaymentCalculatorViewModel" />
internal sealed class MortgageRepaymentCalculatorViewModel : BindableBase, IMortgageRepaymentCalculatorViewModel
{
    private static readonly string[] FieldNames =
    [
        nameof(MortgageFormModel.MortgageAmount),
        nameof(MortgageFormModel.MortgageTerm),
        nameof(MortgageFormModel.InterestRate),
        nameof(MortgageFormModel.MortgageType)
    ];

    private readonly DataErrorsContainer _errors;
    private readonly IMortgageFormValidator _mortgageFormValidator;
    private readonly IMortgageRepaymentBindableModelFactory _mortgageRepaymentFactory;
    private readonly IMortgageRepaymentsService _mortgageRepaymentsService;

    public MortgageRepaymentCalculatorViewModel(
        IMortgageRepaymentBindableModelFactory mortgageRepaymentFactory,
        IMortgageRepaymentsService mortgageRepaymentsService,
        IMortgageFormValidator mortgageFormValidator)
    {
        _mortgageRepaymentFactory = mortgageRepaymentFactory;
        _mortgageRepaymentsService = mortgageRepaymentsService;
        _mortgageFormValidator = mortgageFormValidator;
        _errors = new DataErrorsContainer(this);
    }

    /// <inheritdoc />
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged
    {
        add => _errors.ErrorsChanged += value;
        remove => _errors.ErrorsChanged -= value;
    }

    /// <inheritdoc />
    public bool HasErrors => _errors.HasErrors;

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
                _errors.ClearError(nameof(MortgageAmount));
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
                _errors.ClearError(nameof(MortgageTerm));
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
                _errors.ClearError(nameof(InterestRate));
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
                _errors.ClearError(nameof(MortgageType));
            }
        }
    }

    /// <inheritdoc />
    public IMortgageRepaymentBindableModel? MortgageRepayment
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public IEnumerable GetErrors(string? propertyName)
    {
        return _errors.GetErrors(propertyName);
    }

    /// <summary>
    ///     Validates the form and, when it is valid, calculates the repayments.
    /// </summary>
    /// <returns>A task that completes when the repayments are calculated or the form is found invalid.</returns>
    private async Task CalculateRepaymentsAsync()
    {
        var mortgageForm = new MortgageFormModel
        {
            MortgageAmount = MortgageAmount,
            MortgageTerm = MortgageTerm,
            InterestRate = InterestRate,
            MortgageType = MortgageType
        };

        var mortgageFormValidation = _mortgageFormValidator.Validate(mortgageForm);

        foreach (var fieldName in FieldNames)
        {
            _errors.SetError(fieldName, mortgageFormValidation.Errors.GetValueOrDefault(fieldName));
        }

        if (mortgageFormValidation.Mortgage is not { } mortgage)
        {
            MortgageRepayment = null;

            return;
        }

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
        MortgageRepayment = null;
        _errors.ClearErrors();
    }
}