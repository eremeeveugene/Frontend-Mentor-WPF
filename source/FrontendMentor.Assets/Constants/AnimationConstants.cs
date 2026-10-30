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

using System.Windows;

namespace FrontendMentor.Assets.Constants;

/// <summary>
///     Constants for animations.
/// </summary>
public static class AnimationConstants
{
    private const double GenericAnimationDurationMilliseconds = 300;

    /// <summary>
    ///     Gets the duration of generic animations as a time span.
    /// </summary>
    private static TimeSpan GenericAnimationDurationTimeSpan =>
        TimeSpan.FromMilliseconds(GenericAnimationDurationMilliseconds);

    /// <summary>
    ///     Gets the duration of generic animations.
    /// </summary>
    public static Duration GenericAnimationDuration => new(GenericAnimationDurationTimeSpan);
}