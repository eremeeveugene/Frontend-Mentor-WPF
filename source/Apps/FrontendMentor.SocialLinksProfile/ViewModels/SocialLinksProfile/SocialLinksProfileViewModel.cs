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
using FrontendMentor.SocialLinksProfile.Factories.SocialLinkProfile;
using FrontendMentor.SocialLinksProfile.Services.SocialLinkProfiles;

namespace FrontendMentor.SocialLinksProfile.ViewModels.SocialLinksProfile;

/// <inheritdoc cref="ISocialLinksProfileViewModel" />
internal sealed class SocialLinksProfileViewModel : BindableBase, ISocialLinksProfileViewModel
{
    private readonly ISocialLinkProfileBindableModelFactory _socialLinkProfileFactory;
    private readonly ISocialLinkProfilesService _socialLinkProfilesService;

    public SocialLinksProfileViewModel(
        ISocialLinkProfileBindableModelFactory socialLinkProfileFactory,
        ISocialLinkProfilesService socialLinkProfilesService)
    {
        _socialLinkProfileFactory = socialLinkProfileFactory;
        _socialLinkProfilesService = socialLinkProfilesService;
    }

    /// <inheritdoc />
    public ISocialLinkProfileBindableModel? SocialLinkProfile
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public async Task LoadAsync(CancellationToken cancellationToken)
    {
        var socialLinkProfile = await _socialLinkProfilesService.GetSocialLinkProfileAsync(cancellationToken);

        SocialLinkProfile = _socialLinkProfileFactory.Create(socialLinkProfile);
    }
}