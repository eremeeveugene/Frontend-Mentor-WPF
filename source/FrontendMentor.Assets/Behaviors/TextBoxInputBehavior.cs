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

using FrontendMentor.Assets.Enums;
using FrontendMentor.Assets.Properties;
using Microsoft.Xaml.Behaviors;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FrontendMentor.Assets.Behaviors;

/// <summary>
///     A behavior that restricts the input of a TextBox based on a specified input type, either integer or double.
///     It validates input via regular expressions during text input and pasting operations.
/// </summary>
public partial class TextBoxInputBehavior : Behavior<TextBox>
{
    private const string IntegerRegexPattern = @"^\d+$";
    private const string DoubleRegexPattern = @"^[0-9]+(\.[0-9]+)?$";

    public static readonly DependencyProperty TextBoxInputTypeProperty =
        DependencyProperty.Register(nameof(TextBoxInputType), typeof(TextBoxInputType),
            typeof(TextBoxInputBehavior),
            new PropertyMetadata(TextBoxInputType.Integer));

    /// <summary>
    ///     Gets or sets the input type restriction for the TextBox. Supported input types are Integer and Double.
    /// </summary>
    public TextBoxInputType TextBoxInputType
    {
        get => (TextBoxInputType)GetValue(TextBoxInputTypeProperty);
        set => SetValue(TextBoxInputTypeProperty, value);
    }

    [GeneratedRegex(IntegerRegexPattern)]
    private static partial Regex IntegerRegex();

    [GeneratedRegex(DoubleRegexPattern)]
    private static partial Regex DoubleRegex();

    /// <summary>
    ///     Called when the behavior is attached to the TextBox. Adds event handlers for text input and pasting operations.
    /// </summary>
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.PreviewTextInput += OnPreviewTextInput;
        DataObject.AddPastingHandler(AssociatedObject, OnPasting);
    }

    /// <summary>
    ///     Called when the behavior is detached from the TextBox. Removes event handlers for text input and pasting
    ///     operations.
    /// </summary>
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
        DataObject.RemovePastingHandler(AssociatedObject, OnPasting);
    }

    /// <summary>
    ///     Handles the text input event to restrict user input based on the TextBoxInputType.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The text input event arguments.</param>
    private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !IsInputValid(e.Text);
    }

    /// <summary>
    ///     Handles the pasting event to restrict pasted text based on the TextBoxInputType.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The data object pasting event arguments.</param>
    private void OnPasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject?.GetData(typeof(string)) is not string text || !IsInputValid(text))
        {
            e.CancelCommand();
        }
    }

    /// <summary>
    ///     Validates the input string against the selected TextBoxInputType (Integer or Double).
    /// </summary>
    /// <param name="input">The input text to validate.</param>
    /// <returns>True if the input is valid for the current TextBoxInputType, false otherwise.</returns>
    private bool IsInputValid(string input)
    {
        return TextBoxInputType switch
        {
            TextBoxInputType.Integer => IntegerRegex().IsMatch(input),
            TextBoxInputType.Double => DoubleRegex().IsMatch(input),
            _ => throw new ArgumentOutOfRangeException(nameof(input),
                string.Format(Resources.TextBoxInputBehavior_IsInputValid_ArgumentOutOfRangeException_Message,
                    TextBoxInputType, nameof(TextBoxInputType)))
        };
    }
}