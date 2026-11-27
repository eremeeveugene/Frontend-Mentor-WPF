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

using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace FrontendMentor.Assets.Behaviors;

/// <summary>
///     An attached behavior that lets a text box accept only digits, decimal points and thousands separators, when they
///     are typed and when they are pasted.
/// </summary>
/// <remarks>
///     It is an attached property, so a style can turn it on for every text box of a kind. It only limits the
///     characters; whether the text is a valid number is decided by validation.
/// </remarks>
public static class NumberInputBehavior
{
    /// <summary>
    ///     Identifies the IsEnabled attached property.
    /// </summary>
    public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
        "IsEnabled", typeof(bool), typeof(NumberInputBehavior), new PropertyMetadata(false, OnIsEnabledChanged));

    /// <summary>
    ///     Sets a value indicating whether the text box accepts only number characters.
    /// </summary>
    /// <param name="element">The text box.</param>
    /// <param name="value">Whether the behavior is on.</param>
    public static void SetIsEnabled(DependencyObject element, bool value)
    {
        element.SetValue(IsEnabledProperty, value);
    }

    /// <summary>
    ///     Gets a value indicating whether the text box accepts only number characters.
    /// </summary>
    /// <param name="element">The text box.</param>
    /// <returns>Whether the behavior is on.</returns>
    public static bool GetIsEnabled(DependencyObject element)
    {
        return (bool)element.GetValue(IsEnabledProperty);
    }

    /// <summary>
    ///     Gets a value indicating whether the text may be part of a number.
    /// </summary>
    /// <param name="text">The text that is typed or pasted.</param>
    /// <returns><c>true</c> when the text has only digits, decimal points and thousands separators.</returns>
    internal static bool IsNumberText(string text)
    {
        foreach (var character in text)
        {
            if (!char.IsAsciiDigit(character) && character != '.' && character != ',')
            {
                return false;
            }
        }

        return true;
    }

    private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not TextBoxBase textBox)
        {
            return;
        }

        textBox.PreviewTextInput -= OnPreviewTextInput;
        textBox.PreviewKeyDown -= OnPreviewKeyDown;
        DataObject.RemovePastingHandler(textBox, OnPasting);

        if (e.NewValue is true)
        {
            textBox.PreviewTextInput += OnPreviewTextInput;
            textBox.PreviewKeyDown += OnPreviewKeyDown;
            DataObject.AddPastingHandler(textBox, OnPasting);
        }
    }

    private static void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!IsNumberText(e.Text))
        {
            e.Handled = true;
        }
    }

    private static void OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        // A space is not reported as text input, so it is blocked as a key.
        if (e.Key == Key.Space)
        {
            e.Handled = true;
        }
    }

    private static void OnPasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetData(DataFormats.UnicodeText) is not string text || !IsNumberText(text))
        {
            e.CancelCommand();
        }
    }
}