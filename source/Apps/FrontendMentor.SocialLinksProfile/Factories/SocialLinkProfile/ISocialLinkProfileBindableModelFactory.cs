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

using FrontendMentor.SocialLinksProfile.BindableModels.SocialLinkProfile;
using FrontendMentor.SocialLinksProfile.Models.SocialLinkProfiles;

namespace FrontendMentor.SocialLinksProfile.Factories.SocialLinkProfile;

/// <summary>
///     Creates the presentation models of social link profiles.
/// </summary>
internal interface ISocialLinkProfileBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of a social link profile.
    /// </summary>
    /// <param name="socialLinkProfile">The data of a social link profile.</param>
    /// <returns>The presentation model.</returns>
    ISocialLinkProfileBindableModel Create(SocialLinkProfileModel socialLinkProfile);
}