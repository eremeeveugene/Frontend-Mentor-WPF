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
using System.Windows.Controls;

namespace FrontendMentor.Assets.Controls.Panels;

/// <summary>
///     A panel that stacks its visible children in one direction and adds a fixed spacing between them.
/// </summary>
public sealed class SpacingStackPanel : Panel
{
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
        nameof(Orientation), typeof(Orientation), typeof(SpacingStackPanel),
        new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsMeasure));

    public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register(
        nameof(Spacing), typeof(double), typeof(SpacingStackPanel),
        new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    ///     Gets or sets the direction in which the children are stacked.
    /// </summary>
    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    /// <summary>
    ///     Gets or sets the spacing between the visible children.
    /// </summary>
    public double Spacing
    {
        get => (double)GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    /// <inheritdoc />
    protected override Size MeasureOverride(Size constraint)
    {
        var isHorizontal = Orientation == Orientation.Horizontal;
        var spacing = Spacing;

        var childConstraint = isHorizontal
            ? new Size(double.PositiveInfinity, constraint.Height)
            : new Size(constraint.Width, double.PositiveInfinity);

        double stackLength = 0;
        double crossLength = 0;
        var hasVisibleChild = false;

        var children = InternalChildren;

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];

            if (child.Visibility == Visibility.Collapsed)
            {
                continue;
            }

            child.Measure(childConstraint);

            var desiredSize = child.DesiredSize;

            if (hasVisibleChild)
            {
                stackLength += spacing;
            }

            hasVisibleChild = true;

            if (isHorizontal)
            {
                stackLength += desiredSize.Width;
                crossLength = Math.Max(crossLength, desiredSize.Height);
            }
            else
            {
                stackLength += desiredSize.Height;
                crossLength = Math.Max(crossLength, desiredSize.Width);
            }
        }

        return isHorizontal ? new Size(stackLength, crossLength) : new Size(crossLength, stackLength);
    }

    /// <inheritdoc />
    protected override Size ArrangeOverride(Size arrangeSize)
    {
        var isHorizontal = Orientation == Orientation.Horizontal;
        var spacing = Spacing;

        double offset = 0;
        var hasVisibleChild = false;

        var children = InternalChildren;

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];

            if (child.Visibility == Visibility.Collapsed)
            {
                continue;
            }

            if (hasVisibleChild)
            {
                offset += spacing;
            }

            hasVisibleChild = true;

            var desiredSize = child.DesiredSize;

            if (isHorizontal)
            {
                child.Arrange(new Rect(offset, 0, desiredSize.Width, arrangeSize.Height));

                offset += desiredSize.Width;
            }
            else
            {
                child.Arrange(new Rect(0, offset, arrangeSize.Width, desiredSize.Height));

                offset += desiredSize.Height;
            }
        }

        return arrangeSize;
    }
}