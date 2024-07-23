﻿// --------------------------------------------------------------------------------
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

namespace FrontendMentor.SocialLinksProfile.Controls.Windows;

internal class SocialLinksProfileWindow(FrontendMentorWindow.Dependencies dependencies)
    : FrontendMentorWindow(dependencies)
{
    static SocialLinksProfileWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SocialLinksProfileWindow),
            new FrameworkPropertyMetadata(typeof(SocialLinksProfileWindow)));
    }
}