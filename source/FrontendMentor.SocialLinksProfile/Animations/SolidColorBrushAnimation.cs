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
using System.Windows.Media.Animation;

namespace FrontendMentor.SocialLinksProfile.Animations;

public class SolidColorBrushAnimation : AnimationTimeline
{
    public static readonly DependencyProperty FromProperty = DependencyProperty.Register(
        nameof(From), typeof(SolidColorBrush), typeof(SolidColorBrushAnimation),
        new PropertyMetadata(default(SolidColorBrush)));

    public static readonly DependencyProperty ToProperty = DependencyProperty.Register(
        nameof(To), typeof(SolidColorBrush), typeof(SolidColorBrushAnimation),
        new PropertyMetadata(default(SolidColorBrush)));

    public static readonly DependencyProperty CurrentProperty = DependencyProperty.Register(
        nameof(Current), typeof(SolidColorBrush), typeof(SolidColorBrushAnimation),
        new PropertyMetadata(default(SolidColorBrush)));

    public SolidColorBrush? From
    {
        get => (SolidColorBrush)GetValue(FromProperty);
        set => SetValue(FromProperty, value);
    }

    public SolidColorBrush? To
    {
        get => (SolidColorBrush)GetValue(ToProperty);
        set => SetValue(ToProperty, value);
    }

    public SolidColorBrush Current
    {
        get => (SolidColorBrush)GetValue(CurrentProperty);
        set => SetValue(CurrentProperty, value);
    }

    public override Type TargetPropertyType => typeof(SolidColorBrush);

    protected override Freezable CreateInstanceCore()
    {
        return new SolidColorBrushAnimation();
    }

    public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue,
        AnimationClock animationClock)
    {
        if (animationClock.CurrentProgress == null)
        {
            return defaultOriginValue;
        }

        // Interpolating the color
        var fromColor = From?.Color ?? default(Color);
        var toColor = To?.Color ?? default(Color);
        var progress = animationClock.CurrentProgress.Value;

        var a = (byte)(((toColor.A - fromColor.A) * progress) + fromColor.A);
        var r = (byte)(((toColor.R - fromColor.R) * progress) + fromColor.R);
        var g = (byte)(((toColor.G - fromColor.G) * progress) + fromColor.G);
        var b = (byte)(((toColor.B - fromColor.B) * progress) + fromColor.B);

        // Interpolating the opacity
        var fromOpacity = From?.Opacity ?? 1.0; // Defaulting to fully opaque if not set
        var toOpacity = To?.Opacity ?? 1.0; // Defaulting to fully opaque if not set
        var opacity = ((toOpacity - fromOpacity) * progress) + fromOpacity;

        Current.Color = Color.FromArgb(a, r, g, b);
        Current.Opacity = opacity;
       
        return Current;
    }
}