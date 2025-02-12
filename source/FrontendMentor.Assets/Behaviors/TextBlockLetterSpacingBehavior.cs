// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using Microsoft.Xaml.Behaviors;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FrontendMentor.Assets.Behaviors;

public class TextBlockLetterSpacingBehavior : Behavior<TextBlock>
{
    public static readonly DependencyProperty LetterSpacingProperty =
        DependencyProperty.Register(nameof(LetterSpacing),
            typeof(double),
            typeof(TextBlockLetterSpacingBehavior),
            new PropertyMetadata(0.0,
                (o, _) => ((TextBlockLetterSpacingBehavior)o).OnLetterSpacingChanged()));

    public double LetterSpacing
    {
        get => (double)GetValue(LetterSpacingProperty);
        set => SetValue(LetterSpacingProperty,
            value);
    }

    private void OnLetterSpacingChanged()
    {
        ApplyLetterSpacing();
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        if (AssociatedObject == null)
        {
            return;
        }

        var descriptor = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty,
            typeof(TextBlock));
        descriptor.AddValueChanged(AssociatedObject,
            OnAssociatedObjectTextChanged);

        ApplyLetterSpacing();
    }

    private void OnAssociatedObjectTextChanged(object? sender, EventArgs e)
    {
        ApplyLetterSpacing();
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        if (AssociatedObject == null)
        {
            return;
        }

        var descriptor = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty,
            typeof(TextBlock));
        descriptor.RemoveValueChanged(AssociatedObject,
            OnAssociatedObjectTextChanged);

        AssociatedObject.TextEffects.Clear();
    }

    private void ApplyLetterSpacing()
    {
        if (AssociatedObject == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(AssociatedObject.Text) || LetterSpacing == 0)
        {
            AssociatedObject.TextEffects.Clear();

            return;
        }

        var textEffects = new TextEffectCollection();

        for (var i = 0; i < AssociatedObject.Text.Length; i++)
        {
            var textEffect = new TextEffect
            {
                PositionStart = i,
                PositionCount = 1,
                Transform = new TranslateTransform(i * LetterSpacing,
                    0)
            };

            textEffects.Add(textEffect);
        }

        AssociatedObject.TextEffects = textEffects;
    }
}