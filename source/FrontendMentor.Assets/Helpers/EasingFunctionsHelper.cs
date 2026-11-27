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

using System.Windows.Media.Animation;

namespace FrontendMentor.Assets.Helpers;

/// <summary>
///     Provides shared easing functions.
/// </summary>
public static class EasingFunctionsHelper
{
    /// <summary>
    ///     Gets the easing function that generic animations use.
    /// </summary>
    public static IEasingFunction GenericEasingFunction { get; } = GetGenericEasingFunction();

    /// <summary>
    ///     Creates the frozen easing function that generic animations use.
    /// </summary>
    private static ExponentialEase GetGenericEasingFunction()
    {
        var exponentialEase = new ExponentialEase { EasingMode = EasingMode.EaseOut };

        exponentialEase.Freeze();

        return exponentialEase;
    }
}