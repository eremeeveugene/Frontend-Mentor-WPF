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

using FrontendMentor.BlogPreviewCard.Models;

namespace FrontendMentor.BlogPreviewCard.BindableModels.BlogAuthor;

/// <summary>
///     The parameters that are needed to create the bindable model of a blog author.
/// </summary>
internal sealed class BlogAuthorBindableModelParameters
{
    public BlogAuthorBindableModelParameters(BlogAuthorModel blogAuthor)
    {
        BlogAuthor = blogAuthor;
    }

    /// <summary>
    ///     Gets the blog author.
    /// </summary>
    public BlogAuthorModel BlogAuthor { get; }
}