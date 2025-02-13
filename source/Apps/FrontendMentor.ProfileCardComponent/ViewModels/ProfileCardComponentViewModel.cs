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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.ProfileCardComponent.BindableModels;
using FrontendMentor.ProfileCardComponent.Services.Profiles;

namespace FrontendMentor.ProfileCardComponent.ViewModels;

internal sealed class ProfileCardComponentViewModel(
    IContainerProvider containerProvider,
    IProfilesService profilesService) : NavigationViewModelBase
{
    private ProfileCardComponentBindableModel _profile = null!;

    public ProfileCardComponentBindableModel Profile
    {
        get => _profile;
        private set => SetProperty(ref _profile, value);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        var profile = profilesService.GetProfile();

        Profile = ProfileCardComponentBindableModel.Create(containerProvider,
            new ProfileCardComponentBindableModel.Parameters(profile));
    }
}