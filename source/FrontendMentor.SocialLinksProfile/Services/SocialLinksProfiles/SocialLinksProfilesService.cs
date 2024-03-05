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

using FrontendMentor.SocialLinksProfile.Models;

namespace FrontendMentor.SocialLinksProfile.Services.SocialLinksProfiles;

internal class SocialLinksProfilesService : ISocialLinksProfilesService
{
    public IEnumerable<SocialLinkProfileModel> GetSocialLinkProfiles()
    {
        yield return new SocialLinkProfileModel { Name = "GitHub", Link = "https://github.com/" };
        yield return new SocialLinkProfileModel { Name = "Frontend Mentor", Link = "https://frontendmentor.io/" };
        yield return new SocialLinkProfileModel { Name = "LinkedIn", Link = "https://linkedin.com/" };
        yield return new SocialLinkProfileModel { Name = "Twitter", Link = "https://twitter.com/" };
        yield return new SocialLinkProfileModel { Name = "Instagram", Link = "https://instagram.com/" };
    }
}