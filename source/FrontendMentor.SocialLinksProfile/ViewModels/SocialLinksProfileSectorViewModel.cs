﻿// --------------------------------------------------------------------------------
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
using FrontendMentor.SocialLinksProfile.Services.SocialLinksProfiles;
using Prism.Ioc;
using System.Collections.ObjectModel;

namespace FrontendMentor.SocialLinksProfile.ViewModels;

internal sealed class SocialLinksProfileSectorViewModel(
    ISocialLinksProfilesService socialLinksProfilesService,
    IContainerProvider containerProvider)
    : ViewModelBase
{
    private ObservableCollection<SocialLinkProfileBindableModel>? _socialLinksProfiles;

    public ObservableCollection<SocialLinkProfileBindableModel>? SocialLinksProfiles
    {
        get => _socialLinksProfiles;
        private set => SetProperty(ref _socialLinksProfiles, value);
    }

    protected override Task LoadedOnceAsync()
    {
        LoadSocialLinksProfiles();

        return base.LoadedOnceAsync();
    }

    private void LoadSocialLinksProfiles()
    {
        var socialLinkProfiles = socialLinksProfilesService.GetSocialLinkProfiles();

        var socialLinkProfilesViewModels = socialLinkProfiles
            .Select(socialLinkProfile => SocialLinkProfileBindableModel.Create(containerProvider, socialLinkProfile));

        SocialLinksProfiles = new ObservableCollection<SocialLinkProfileBindableModel>(socialLinkProfilesViewModels);
    }
}