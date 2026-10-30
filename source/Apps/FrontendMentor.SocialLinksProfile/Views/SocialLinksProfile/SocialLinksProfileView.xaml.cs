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

using FrontendMentor.SocialLinksProfile.ViewModels.SocialLinksProfile;

namespace FrontendMentor.SocialLinksProfile.Views.SocialLinksProfile;

/// <inheritdoc cref="ISocialLinksProfileView" />
internal sealed partial class SocialLinksProfileView : ISocialLinksProfileView
{
    public SocialLinksProfileView(ISocialLinksProfileViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}