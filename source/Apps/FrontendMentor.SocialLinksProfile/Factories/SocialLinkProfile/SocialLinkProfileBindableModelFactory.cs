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

using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.SocialLinksProfile.BindableModels.SocialLinkProfile;
using FrontendMentor.SocialLinksProfile.Factories.SocialLink;
using FrontendMentor.SocialLinksProfile.Models.SocialLinkProfiles;
using Microsoft.Extensions.Logging;

namespace FrontendMentor.SocialLinksProfile.Factories.SocialLinkProfile;

/// <inheritdoc />
internal sealed class SocialLinkProfileBindableModelFactory : ISocialLinkProfileBindableModelFactory
{
    private readonly IBitmapImagesService _bitmapImagesService;
    private readonly ILogger<SocialLinkProfileBindableModel> _logger;
    private readonly ISocialLinkBindableModelFactory _socialLinkFactory;

    public SocialLinkProfileBindableModelFactory(
        IBitmapImagesService bitmapImagesService,
        ISocialLinkBindableModelFactory socialLinkFactory,
        ILogger<SocialLinkProfileBindableModel> logger)
    {
        _bitmapImagesService = bitmapImagesService;
        _socialLinkFactory = socialLinkFactory;
        _logger = logger;
    }

    /// <inheritdoc />
    public ISocialLinkProfileBindableModel Create(SocialLinkProfileModel socialLinkProfile)
    {
        return new SocialLinkProfileBindableModel(_bitmapImagesService, _socialLinkFactory, _logger, socialLinkProfile);
    }
}