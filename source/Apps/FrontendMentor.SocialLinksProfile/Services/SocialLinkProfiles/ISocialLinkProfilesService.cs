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


using FrontendMentor.SocialLinksProfile.Models.SocialLinkProfiles;

namespace FrontendMentor.SocialLinksProfile.Services.SocialLinkProfiles;

/// <summary>
///     Provides social link profiles.
/// </summary>
internal interface ISocialLinkProfilesService
{
    /// <summary>
    ///     Gets the social link profile that the view shows.
    /// </summary>
    /// <param name="cancellationToken">The token that cancels the request.</param>
    /// <returns>A task that completes with the social link profile.</returns>
    /// <remarks>
    ///     The method is asynchronous to simulate retrieving the profile from a backend service.
    ///     The data is local, so the task completes immediately.
    /// </remarks>
    Task<SocialLinkProfileModel> GetSocialLinkProfileAsync(CancellationToken cancellationToken = default);
}