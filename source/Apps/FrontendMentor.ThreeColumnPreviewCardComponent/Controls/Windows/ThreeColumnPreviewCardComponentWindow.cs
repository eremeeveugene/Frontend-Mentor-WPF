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

using FrontendMentor.Assets.Controls.Windows;
using System.Windows;

namespace FrontendMentor.ThreeColumnPreviewCardComponent.Controls.Windows;

internal class ThreeColumnPreviewCardComponentWindow : FrontendMentorWindow
{
    static ThreeColumnPreviewCardComponentWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ThreeColumnPreviewCardComponentWindow),
            new FrameworkPropertyMetadata(typeof(ThreeColumnPreviewCardComponentWindow)));
    }
}