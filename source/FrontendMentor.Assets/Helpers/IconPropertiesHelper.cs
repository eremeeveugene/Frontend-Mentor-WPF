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
using System.Windows.Media;

namespace FrontendMentor.Assets.Helpers;

public static class IconPropertiesHelper
{
    public static readonly DependencyProperty FillProperty = DependencyProperty.RegisterAttached(
        "Fill", typeof(Brush), typeof(IconPropertiesHelper),
        new PropertyMetadata(default(Brush)));

    public static readonly DependencyProperty DataProperty = DependencyProperty.RegisterAttached(
        "Data", typeof(Geometry), typeof(IconPropertiesHelper), new PropertyMetadata(default(Geometry)));

    public static readonly DependencyProperty WidthProperty = DependencyProperty.RegisterAttached(
        "Width", typeof(double), typeof(IconPropertiesHelper), new PropertyMetadata(default(double)));

    public static void SetFill(DependencyObject element, Brush value)
    {
        element.SetValue(FillProperty, value);
    }

    public static Brush GetFill(DependencyObject element)
    {
        return (Brush)element.GetValue(FillProperty);
    }

    public static void SetData(DependencyObject element, Geometry value)
    {
        element.SetValue(DataProperty, value);
    }

    public static Geometry GetData(DependencyObject element)
    {
        return (Geometry)element.GetValue(DataProperty);
    }

    public static void SetWidth(DependencyObject element, double value)
    {
        element.SetValue(WidthProperty, value);
    }

    public static double GetWidth(DependencyObject element)
    {
        return (double)element.GetValue(WidthProperty);
    }
}