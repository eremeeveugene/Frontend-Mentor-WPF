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

public static class UIElementPropertiesHelper
{
    public static readonly DependencyProperty IsMouseOverParentProperty = DependencyProperty.RegisterAttached(
        "IsMouseOverParent", typeof(bool), typeof(UIElementPropertiesHelper), new PropertyMetadata(default(bool)));

    public static void SetIsMouseOverParent(DependencyObject element, bool value)
    {
        element.SetValue(IsMouseOverParentProperty, value);
    }

    public static bool GetIsMouseOverParent(DependencyObject element)
    {
        return (bool)element.GetValue(IsMouseOverParentProperty);
    }
}