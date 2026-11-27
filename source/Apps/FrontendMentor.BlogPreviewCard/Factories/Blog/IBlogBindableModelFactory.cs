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

using FrontendMentor.BlogPreviewCard.BindableModels.Blog;
using FrontendMentor.BlogPreviewCard.Models.Blogs;

namespace FrontendMentor.BlogPreviewCard.Factories.Blog;

/// <summary>
///     Creates the presentation models of blogs.
/// </summary>
internal interface IBlogBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of a blog.
    /// </summary>
    /// <param name="blog">The data of a blog.</param>
    /// <returns>The presentation model.</returns>
    IBlogBindableModel Create(BlogModel blog);
}