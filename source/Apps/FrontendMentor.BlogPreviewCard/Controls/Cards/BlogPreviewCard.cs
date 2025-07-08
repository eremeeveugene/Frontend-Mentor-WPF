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

using FrontendMentor.BlogPreviewCard.BindableModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FrontendMentor.BlogPreviewCard.Controls.Cards;

[TemplateVisualState(Name = NormalStateName, GroupName = CommonStatesGroupName)]
[TemplateVisualState(Name = MouseOverStateName, GroupName = CommonStatesGroupName)]
internal class BlogPreviewCard : Control
{
    private const string NormalStateName = "Normal";
    private const string MouseOverStateName = "MouseOver";
    private const string CommonStatesGroupName = "CommonStates";

    public static readonly DependencyProperty BlogProperty = DependencyProperty.Register(
        nameof(Blog), typeof(BlogBindableModel), typeof(BlogPreviewCard),
        new PropertyMetadata(default(BlogBindableModel)));

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius), typeof(CornerRadius), typeof(BlogPreviewCard),
        new PropertyMetadata(default(CornerRadius)));

    private bool _isTemplateApplied;

    static BlogPreviewCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BlogPreviewCard),
            new FrameworkPropertyMetadata(typeof(BlogPreviewCard)));
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public BlogBindableModel Blog
    {
        get => (BlogBindableModel)GetValue(BlogProperty);
        set => SetValue(BlogProperty, value);
    }

    protected override void OnMouseEnter(MouseEventArgs e)
    {
        base.OnMouseEnter(e);

        UpdateState();
    }

    protected override void OnMouseLeave(MouseEventArgs e)
    {
        base.OnMouseLeave(e);

        UpdateState();
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        try
        {
            UpdateState();
        }
        finally
        {
            _isTemplateApplied = true;
        }
    }

    private void UpdateState()
    {
        var stateName = IsMouseOver ? MouseOverStateName : NormalStateName;

        VisualStateManager.GoToState(this, stateName, _isTemplateApplied);
    }
}