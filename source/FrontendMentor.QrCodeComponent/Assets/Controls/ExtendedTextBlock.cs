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

using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FrontendMentor.QrCodeComponent.Assets.Controls;

public class ExtendedTextBlock : FrameworkElement
{
    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        FormattedText formattedText = new FormattedText(
            "Your Text Here",
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface("Segoe UI"),
            32, // Font size
            Brushes.Black);

        // Use the drawing context to draw your formatted text
        drawingContext.DrawText(formattedText, new Point(0, 0));
    }
}