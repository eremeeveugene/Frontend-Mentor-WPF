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

using FrontendMentor.BlogPreviewCard.Models;

namespace FrontendMentor.BlogPreviewCard.Services.Blogs;

/// <summary>
///     Provides blogs.
/// </summary>
internal interface IBlogsService
{
    /// <summary>
    ///     Gets the blog that the card shows.
    /// </summary>
    /// <returns>The blog.</returns>
    BlogModel GetBlog();
}