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

namespace FrontendMentor.Assets.Helpers;

/// <summary>
///     Attached properties for borders.
/// </summary>
public static class BorderPropertiesHelper
{
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
        "CornerRadius", typeof(CornerRadius), typeof(BorderPropertiesHelper),
        new PropertyMetadata(default(CornerRadius)));

    /// <summary>
    ///     Sets the CornerRadius attached property value of an element.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="value">The value to set.</param>
    public static void SetCornerRadius(DependencyObject element, CornerRadius value)
    {
        element.SetValue(CornerRadiusProperty, value);
    }

    /// <summary>
    ///     Gets the CornerRadius attached property value of an element.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns>The value of the attached property.</returns>
    public static CornerRadius GetCornerRadius(DependencyObject element)
    {
        return (CornerRadius)element.GetValue(CornerRadiusProperty);
    }
}