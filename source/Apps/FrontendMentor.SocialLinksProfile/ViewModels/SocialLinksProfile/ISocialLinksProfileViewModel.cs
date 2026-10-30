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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.SocialLinksProfile.BindableModels.SocialLinkProfile;

namespace FrontendMentor.SocialLinksProfile.ViewModels.SocialLinksProfile;

/// <summary>
///     The view model of the social links profile.
/// </summary>
internal interface ISocialLinksProfileViewModel : IViewModel
{
    /// <summary>
    ///     Gets the profile that the view shows.
    /// </summary>
    ISocialLinkProfileBindableModel SocialLinkProfile { get; }
}