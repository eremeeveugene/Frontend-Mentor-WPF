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

using FrontendMentor.SocialLinksProfile.BindableModels.SocialLink;
using FrontendMentor.SocialLinksProfile.Models.SocialLinks;

namespace FrontendMentor.SocialLinksProfile.Factories.SocialLink;

/// <summary>
///     Creates the presentation models of social links.
/// </summary>
internal interface ISocialLinkBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of a social link.
    /// </summary>
    /// <param name="socialLink">The data of a social link.</param>
    /// <returns>The presentation model.</returns>
    ISocialLinkBindableModel Create(SocialLinkModel socialLink);
}