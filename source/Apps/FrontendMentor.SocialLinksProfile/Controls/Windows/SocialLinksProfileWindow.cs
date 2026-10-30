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
using FrontendMentor.SocialLinksProfile.Views.SocialLinksProfile;
using System.Windows;

namespace FrontendMentor.SocialLinksProfile.Controls.Windows;

/// <inheritdoc cref="ISocialLinksProfileWindow" />
internal sealed class SocialLinksProfileWindow : FrontendMentorWindow, ISocialLinksProfileWindow
{
    static SocialLinksProfileWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SocialLinksProfileWindow),
            new FrameworkPropertyMetadata(typeof(SocialLinksProfileWindow)));
    }

    public SocialLinksProfileWindow(ISocialLinksProfileView view)
        : base(view)
    {
    }
}