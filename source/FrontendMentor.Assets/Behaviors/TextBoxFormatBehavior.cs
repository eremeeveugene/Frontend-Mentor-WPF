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

using Microsoft.Xaml.Behaviors;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace FrontendMentor.Assets.Behaviors;

/// <summary>
///     A behavior that applies a custom numeric format to a TextBox when it loses focus.
///     The format is specified via the Format property.
/// </summary>
public class TextBoxFormatBehavior : Behavior<TextBox>
{
    /// <summary>
    ///     Identifies the Format dependency property. This property is used to define
    ///     the numeric format applied to the TextBox content when it loses focus.
    /// </summary>
    public static readonly DependencyProperty FormatProperty =
        DependencyProperty.Register(nameof(Format), typeof(string), typeof(TextBoxFormatBehavior),
            new PropertyMetadata(default(string)));

    /// <summary>
    ///     Gets or sets the numeric format string that will be applied to the TextBox content.
    /// </summary>
    public string Format
    {
        get => (string)GetValue(FormatProperty);
        set => SetValue(FormatProperty, value);
    }

    /// <summary>
    ///     Called when the behavior is attached to a TextBox.
    ///     Registers the LostFocus event handler.
    /// </summary>
    protected override void OnAttached()
    {
        base.OnAttached();

        AssociatedObject.LostFocus += OnLostFocus;
    }

    /// <summary>
    ///     Called when the behavior is detached from a TextBox.
    ///     Unregisters the LostFocus event handler.
    /// </summary>
    protected override void OnDetaching()
    {
        base.OnDetaching();

        AssociatedObject.LostFocus -= OnLostFocus;
    }

    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(Format))
        {
            return;
        }

        if (decimal.TryParse(AssociatedObject.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
        {
            AssociatedObject.Text = value.ToString(Format, CultureInfo.InvariantCulture);
        }
    }
}