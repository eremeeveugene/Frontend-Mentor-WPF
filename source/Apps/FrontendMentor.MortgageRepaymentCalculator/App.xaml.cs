// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.MortgageRepaymentCalculator.Constants;
using FrontendMentor.MortgageRepaymentCalculator.Controls.Windows;
using FrontendMentor.MortgageRepaymentCalculator.Views;
using System.Windows;

namespace FrontendMentor.MortgageRepaymentCalculator;

internal partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterForNavigation<MortgageRepaymentCalculatorView>(MortgageRepaymentCalculatorViewNames
            .MortgageRepaymentCalculator);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<MortgageRepaymentCalculatorWindow>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigateToShellRegion(MortgageRepaymentCalculatorViewNames.MortgageRepaymentCalculator);
    }
}