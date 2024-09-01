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
using System.Windows.Controls;

namespace FrontendMentor.Assets.Controls.Panels;

public class SpacingStackPanel : StackPanel
{
    public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register(
        nameof(Spacing), typeof(double), typeof(SpacingStackPanel),
        new FrameworkPropertyMetadata(default(double),
            FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

    public double Spacing
    {
        get => (double)GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    protected override Size MeasureOverride(Size constraint)
    {
        double totalWidth = 0;
        double totalHeight = 0;
        double maxWidth = 0;
        double maxHeight = 0;

        foreach (UIElement child in InternalChildren)
        {
            child.Measure(constraint);

            if (Orientation == Orientation.Horizontal)
            {
                totalWidth += child.DesiredSize.Width +
                              (InternalChildren.IndexOf(child) < InternalChildren.Count - 1 ? Spacing : 0);

                maxHeight = Math.Max(maxHeight, child.DesiredSize.Height);
            }
            else
            {
                totalHeight += child.DesiredSize.Height +
                               (InternalChildren.IndexOf(child) < InternalChildren.Count - 1 ? Spacing : 0);

                maxWidth = Math.Max(maxWidth, child.DesiredSize.Width);
            }
        }

        return Orientation == Orientation.Horizontal
            ? new Size(totalWidth, maxHeight)
            : new Size(maxWidth, totalHeight);
    }

    protected override Size ArrangeOverride(Size arrangeSize)
    {
        double offset = 0;

        foreach (UIElement child in InternalChildren)
        {
            if (child.Visibility == Visibility.Collapsed)
            {
                continue;
            }

            if (Orientation == Orientation.Horizontal)
            {
                child.Arrange(new Rect(offset, 0, child.DesiredSize.Width, arrangeSize.Height));
                offset += child.DesiredSize.Width + Spacing;
            }
            else
            {
                child.Arrange(new Rect(0, offset, arrangeSize.Width, child.DesiredSize.Height));
                offset += child.DesiredSize.Height + Spacing;
            }
        }

        return arrangeSize;
    }
}