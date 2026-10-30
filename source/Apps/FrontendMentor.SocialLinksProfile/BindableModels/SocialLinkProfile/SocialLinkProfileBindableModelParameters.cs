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

using FrontendMentor.SocialLinksProfile.Models;

namespace FrontendMentor.SocialLinksProfile.BindableModels.SocialLinkProfile;

/// <summary>
///     The parameters that are needed to create the bindable model of a social link profile.
/// </summary>
internal sealed class SocialLinkProfileBindableModelParameters
{
    public SocialLinkProfileBindableModelParameters(SocialLinkProfileModel socialLinkProfile)
    {
        SocialLinkProfile = socialLinkProfile;
    }

    /// <summary>
    ///     Gets the social link profile.
    /// </summary>
    public SocialLinkProfileModel SocialLinkProfile { get; }
}