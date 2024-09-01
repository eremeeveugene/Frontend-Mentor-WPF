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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.SocialLinksProfile.BindableModels;
using FrontendMentor.SocialLinksProfile.Services.SocialLinkProfiles;

namespace FrontendMentor.SocialLinksProfile.ViewModels;

internal sealed class SocialLinksProfileViewModel(
    ISocialLinkProfilesService socialLinksProfilesService,
    IContainerProvider containerProvider) :
    NavigationViewModelBase
{
    private SocialLinkProfileBindableModel? _socialLinkProfile;

    public SocialLinkProfileBindableModel? SocialLinkProfile
    {
        get => _socialLinkProfile;
        private set => SetProperty(ref _socialLinkProfile, value);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        var socialLinkProfile = socialLinksProfilesService.GetSocialLinkProfile();

        SocialLinkProfile = SocialLinkProfileBindableModel.Create(containerProvider,
            new SocialLinkProfileBindableModel.Parameters { SocialLinkProfile = socialLinkProfile });
    }
}