// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.OrderSummaryComponent.Models.AnnualPlans;

namespace FrontendMentor.OrderSummaryComponent.Services.AnnualPlans;

/// <inheritdoc />
internal sealed class AnnualPlansService : IAnnualPlansService
{
    /// <inheritdoc />
    public Task<AnnualPlanModel> GetAnnualPlanAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var annualPlan = new AnnualPlanModel { Price = 59.99 };

        return Task.FromResult(annualPlan);
    }
}