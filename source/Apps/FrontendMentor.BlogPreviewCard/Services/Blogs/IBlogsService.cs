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


using FrontendMentor.BlogPreviewCard.Models.Blogs;

namespace FrontendMentor.BlogPreviewCard.Services.Blogs;

/// <summary>
///     Provides blogs.
/// </summary>
internal interface IBlogsService
{
    /// <summary>
    ///     Gets the blog that the card shows.
    /// </summary>
    /// <param name="cancellationToken">The token that cancels the request.</param>
    /// <returns>A task that completes with the blog.</returns>
    /// <remarks>
    ///     The method is asynchronous to simulate retrieving the blog from a backend service.
    ///     The data is local, so the task completes immediately.
    /// </remarks>
    Task<BlogModel> GetBlogAsync(CancellationToken cancellationToken = default);
}