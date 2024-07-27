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

using System.Windows;

namespace FrontendMentor.Assets.Helpers;

public static class WindowPropertiesHelper
{
    public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
        "IsActive", typeof(bool), typeof(WindowPropertiesHelper),
        new PropertyMetadata(default(bool)));


    public static readonly DependencyProperty WindowStateProperty = DependencyProperty.RegisterAttached(
        "WindowState", typeof(WindowState), typeof(WindowPropertiesHelper), new PropertyMetadata(default(WindowState)));

    public static void SetIsActive(DependencyObject element, bool value)
    {
        element.SetValue(IsActiveProperty, value);
    }

    public static bool GetIsActive(DependencyObject element)
    {
        return (bool)element.GetValue(IsActiveProperty);
    }

    public static void SetWindowState(DependencyObject element, WindowState value)
    {
        element.SetValue(WindowStateProperty, value);
    }

    public static WindowState GetWindowState(DependencyObject element)
    {
        return (WindowState)element.GetValue(WindowStateProperty);
    }
}