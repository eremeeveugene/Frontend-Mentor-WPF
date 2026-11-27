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

using FrontendMentor.MortgageRepaymentCalculator.BindableModels.MortgageRepayment;
using FrontendMentor.MortgageRepaymentCalculator.Models.MortgageRepayments;

namespace FrontendMentor.MortgageRepaymentCalculator.Factories.MortgageRepayment;

/// <inheritdoc />
internal sealed class MortgageRepaymentBindableModelFactory : IMortgageRepaymentBindableModelFactory
{
    /// <inheritdoc />
    public IMortgageRepaymentBindableModel Create(MortgageRepaymentModel mortgageRepayment)
    {
        return new MortgageRepaymentBindableModel(mortgageRepayment);
    }
}