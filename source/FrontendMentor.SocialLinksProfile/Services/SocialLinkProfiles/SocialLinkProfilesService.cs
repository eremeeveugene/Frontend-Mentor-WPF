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

namespace FrontendMentor.SocialLinksProfile.Services.SocialLinkProfiles;

internal class SocialLinkProfilesService : ISocialLinkProfilesService
{
    public SocialLinkProfileModel GetSocialLinkProfile()
    {
        return new SocialLinkProfileModel
        {
            SocialLinks = new List<SocialLinkModel>
            {
                new() { Name = "GitHub", Link = "https://github.com/" },
                new() { Name = "Frontend Mentor", Link = "https://frontendmentor.io/" },
                new() { Name = "LinkedIn", Link = "https://linkedin.com/" },
                new() { Name = "Twitter", Link = "https://twitter.com/" },
                new() { Name = "Instagram", Link = "https://instagram.com/" }
            }
        };
    }
}