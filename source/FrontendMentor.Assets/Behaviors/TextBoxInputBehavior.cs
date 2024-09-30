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

public partial class TextBoxInputBehavior : Behavior<TextBox>
{
    private const string IntegerRegexPattern = @"^\d+$";
    private const string DoubleRegexPattern = @"^[0-9]+(\.[0-9]+)?$";

    public static readonly DependencyProperty TextBoxInputTypeProperty =
        DependencyProperty.Register(nameof(TextBoxInputType), typeof(TextBoxInputType),
            typeof(TextBoxInputBehavior),
            new PropertyMetadata(TextBoxInputType.Integer));

    public TextBoxInputType TextBoxInputType
    {
        get => (TextBoxInputType)GetValue(TextBoxInputTypeProperty);
        set => SetValue(TextBoxInputTypeProperty, value);
    }

    [GeneratedRegex(IntegerRegexPattern)]
    private static partial Regex IntegerRegex();

    [GeneratedRegex(DoubleRegexPattern)]
    private static partial Regex DoubleRegex();

    protected override void OnAttached()
    {
        base.OnAttached();

        AssociatedObject.PreviewTextInput += OnPreviewTextInput;

        DataObject.AddPastingHandler(AssociatedObject, OnPasting);
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        AssociatedObject.PreviewTextInput -= OnPreviewTextInput;

        DataObject.RemovePastingHandler(AssociatedObject, OnPasting);
    }

    private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !IsInputValid(e.Text);
    }

    private void OnPasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject?.GetData(typeof(string)) is not string text || !IsInputValid(text))
        {
            e.CancelCommand();
        }
    }

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