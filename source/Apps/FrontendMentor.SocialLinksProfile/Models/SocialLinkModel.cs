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

/// <summary>
///     The data of a social link.
/// </summary>
internal sealed class SocialLinkModel
{
    /// <summary>
    ///     Gets or initializes the link.
    /// </summary>
    public required string Link { get; init; }
    /// <summary>
    ///     Gets or initializes the name.
    /// </summary>
    public required string Name { get; init; }
}