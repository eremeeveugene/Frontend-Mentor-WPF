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

using FrontendMentor.SocialLinksProfile.Models.SocialLinks;

namespace FrontendMentor.SocialLinksProfile.Models.SocialLinkProfiles;

/// <summary>
///     The data of a social link profile.
/// </summary>
internal sealed class SocialLinkProfileModel
{
    /// <summary>
    ///     Gets or initializes the first name.
    /// </summary>
    public required string FirstName { get; init; }

    /// <summary>
    ///     Gets or initializes the last name.
    /// </summary>
    public required string LastName { get; init; }

    /// <summary>
    ///     Gets or initializes the title.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    ///     Gets or initializes the Base64 encoded profile image.
    /// </summary>
    public required string ProfileImageBase64String { get; init; }

    /// <summary>
    ///     Gets or initializes the location.
    /// </summary>
    public required string Location { get; init; }

    /// <summary>
    ///     Gets or initializes the social links.
    /// </summary>
    public required IReadOnlyList<SocialLinkModel> SocialLinks { get; init; }
}