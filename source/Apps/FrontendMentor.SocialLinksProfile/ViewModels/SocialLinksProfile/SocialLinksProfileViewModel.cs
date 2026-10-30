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

using FrontendMentor.Core.Bindables;
using FrontendMentor.SocialLinksProfile.BindableModels.SocialLinkProfile;
using FrontendMentor.SocialLinksProfile.Models;
using FrontendMentor.SocialLinksProfile.Services.SocialLinkProfiles;

namespace FrontendMentor.SocialLinksProfile.ViewModels.SocialLinksProfile;

/// <inheritdoc cref="ISocialLinksProfileViewModel" />
internal sealed class SocialLinksProfileViewModel : BindableBase, ISocialLinksProfileViewModel
{
    public SocialLinksProfileViewModel(
        Func<SocialLinkProfileBindableModelParameters, ISocialLinkProfileBindableModel> socialLinkProfileFactory,
        ISocialLinkProfilesService socialLinksProfilesService)
    {
        SocialLinkProfile =
            socialLinkProfileFactory(
            new SocialLinkProfileBindableModelParameters(socialLinksProfilesService.GetSocialLinkProfile()));
    }

    /// <inheritdoc />
    public ISocialLinkProfileBindableModel SocialLinkProfile { get; }
}