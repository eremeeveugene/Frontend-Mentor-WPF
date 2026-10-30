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

namespace FrontendMentor.BlogPreviewCard.Models;

/// <summary>
///     The data of a blog author.
/// </summary>
internal sealed class BlogAuthorModel
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
    ///     Gets or initializes the Base64 encoded image.
    /// </summary>
    public required string ImageBase64String { get; init; }
}