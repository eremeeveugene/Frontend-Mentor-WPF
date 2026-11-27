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
using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageRepayments;

namespace FrontendMentor.MortgageRepaymentCalculator.BindableModels.MortgageRepayment;

/// <inheritdoc cref="IMortgageRepaymentBindableModel" />
internal sealed class MortgageRepaymentBindableModel : BindableBase, IMortgageRepaymentBindableModel
{
    public MortgageRepaymentBindableModel(MortgageRepaymentModel mortgageRepayment)
    {
        MonthlyRepayment = mortgageRepayment.MonthlyRepayment;
        TotalRepayment = mortgageRepayment.TotalRepayment;
    }

    /// <inheritdoc />
    public decimal MonthlyRepayment { get; }

    /// <inheritdoc />
    public decimal TotalRepayment { get; }
}