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

using FrontendMentor.Assets.Controls.Windows;
using FrontendMentor.Assets.Services.Themes;
using FrontendMentor.MortgageRepaymentCalculator.Views.MortgageRepaymentCalculator;
using System.Windows;

namespace FrontendMentor.MortgageRepaymentCalculator.Controls.Windows;

/// <inheritdoc cref="IMortgageRepaymentCalculatorWindow" />
internal sealed class MortgageRepaymentCalculatorWindow : FrontendMentorWindow, IMortgageRepaymentCalculatorWindow
{
    static MortgageRepaymentCalculatorWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MortgageRepaymentCalculatorWindow),
            new FrameworkPropertyMetadata(typeof(MortgageRepaymentCalculatorWindow)));
    }

    public MortgageRepaymentCalculatorWindow(
        IMortgageRepaymentCalculatorView view,
        INativeWindowThemeService nativeWindowThemeService)
        : base(view, nativeWindowThemeService)
    {
    }
}