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

using FrontendMentor.Assets.Controls.Windows;
using FrontendMentor.ThreeColumnPreviewCardComponent.Views.ThreeColumnPreviewCardComponent;
using System.Windows;

namespace FrontendMentor.ThreeColumnPreviewCardComponent.Controls.Windows;

/// <inheritdoc cref="IThreeColumnPreviewCardComponentWindow" />
internal sealed class ThreeColumnPreviewCardComponentWindow : FrontendMentorWindow, IThreeColumnPreviewCardComponentWindow
{
    static ThreeColumnPreviewCardComponentWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ThreeColumnPreviewCardComponentWindow),
            new FrameworkPropertyMetadata(typeof(ThreeColumnPreviewCardComponentWindow)));
    }

    public ThreeColumnPreviewCardComponentWindow(IThreeColumnPreviewCardComponentView view)
        : base(view)
    {
    }
}