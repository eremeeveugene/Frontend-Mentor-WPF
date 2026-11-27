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

using FrontendMentor.Core.Services.Processes;
using FrontendMentor.SocialLinksProfile.BindableModels.SocialLink;
using FrontendMentor.SocialLinksProfile.Models.SocialLinks;

namespace FrontendMentor.SocialLinksProfile.Factories.SocialLink;

/// <inheritdoc />
internal sealed class SocialLinkBindableModelFactory : ISocialLinkBindableModelFactory
{
    private readonly IProcessesService _processesService;

    public SocialLinkBindableModelFactory(IProcessesService processesService)
    {
        _processesService = processesService;
    }

    /// <inheritdoc />
    public ISocialLinkBindableModel Create(SocialLinkModel socialLink)
    {
        return new SocialLinkBindableModel(_processesService, socialLink);
    }
}