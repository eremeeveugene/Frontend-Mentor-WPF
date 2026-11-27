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

using FrontendMentor.Assets.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FrontendMentor.Assets.Tests.Behaviors;

[TestClass]
public sealed class NumberInputBehaviorTests
{
    [TestMethod]
    [DataRow("7")]
    [DataRow("300,000")]
    [DataRow("5.25")]
    public void IsNumberText_DigitsAndSeparators_IsTrue(string text)
    {
        Assert.IsTrue(NumberInputBehavior.IsNumberText(text));
    }

    [TestMethod]
    [DataRow("a")]
    [DataRow("-")]
    [DataRow(" ")]
    [DataRow("٣")]
    public void IsNumberText_OtherCharacters_IsFalse(string text)
    {
        Assert.IsFalse(NumberInputBehavior.IsNumberText(text));
    }

    [STATestMethod]
    [DataRow("5", false)]
    [DataRow("x", true)]
    public void PreviewTextInput_Enabled_BlocksOnlyOtherCharacters(string text, bool expectedHandled)
    {
        var textBox = new TextBox();

        NumberInputBehavior.SetIsEnabled(textBox, true);

        Assert.AreEqual(expectedHandled, RaisePreviewTextInput(textBox, text));
    }

    [STATestMethod]
    public void PreviewTextInput_Disabled_BlocksNothing()
    {
        var textBox = new TextBox();

        NumberInputBehavior.SetIsEnabled(textBox, true);
        NumberInputBehavior.SetIsEnabled(textBox, false);

        Assert.IsFalse(RaisePreviewTextInput(textBox, "x"));
    }

    private static bool RaisePreviewTextInput(TextBox textBox, string text)
    {
        var args = new TextCompositionEventArgs(Keyboard.PrimaryDevice, new TextComposition(InputManager.Current, textBox, text))
        {
            RoutedEvent = UIElement.PreviewTextInputEvent
        };

        textBox.RaiseEvent(args);

        return args.Handled;
    }
}