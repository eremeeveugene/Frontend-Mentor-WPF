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

namespace FrontendMentor.BlogPreviewCard.Models;

/// <summary>
///     The data of a blog.
/// </summary>
internal sealed class BlogModel
{
    /// <summary>
    ///     Gets or initializes the title.
    /// </summary>
    public required string Title { get; init; }
    /// <summary>
    ///     Gets or initializes the description.
    /// </summary>
    public required string Description { get; init; }
    /// <summary>
    ///     Gets or initializes the category.
    /// </summary>
    public required string Category { get; init; }
    /// <summary>
    ///     Gets or initializes the Base64 encoded image.
    /// </summary>
    public required string ImageBase64String { get; init; }
    /// <summary>
    ///     Gets or initializes the date when the blog was published.
    /// </summary>
    public required DateTime PublishedDate { get; init; }
    /// <summary>
    ///     Gets or initializes the author of the blog.
    /// </summary>
    public required BlogAuthorModel BlogAuthor { get; init; }
}