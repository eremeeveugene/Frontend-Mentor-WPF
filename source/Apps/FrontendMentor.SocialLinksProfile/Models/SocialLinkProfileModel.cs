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

namespace FrontendMentor.SocialLinksProfile.Models;

internal class SocialLinkProfileModel
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string ProfileImageBase64String { get; set; } = null!;

    public string Location { get; set; } = null!;

    public IEnumerable<SocialLinkModel> SocialLinks { get; set; } = null!;
}