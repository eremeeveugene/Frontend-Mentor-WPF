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

namespace FrontendMentor.BlogPreviewCard.BindableModels.Blog;

/// <summary>
///     The parameters that are needed to create the bindable model of a blog.
/// </summary>
internal sealed class BlogBindableModelParameters
{
    public BlogBindableModelParameters(BlogModel blog)
    {
        Blog = blog;
    }

    /// <summary>
    ///     Gets the blog.
    /// </summary>
    public BlogModel Blog { get; }
}