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

namespace FrontendMentor.Assets.Controls.Windows;

public class FrontendMentorWindow : Window
{
    static FrontendMentorWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FrontendMentorWindow),
            new FrameworkPropertyMetadata(typeof(FrontendMentorWindow)));
    }
}