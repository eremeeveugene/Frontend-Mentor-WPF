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

using FrontendMentor.BlogPreviewCard.BindableModels.BlogAuthor;
using FrontendMentor.BlogPreviewCard.Models.BlogAuthors;

namespace FrontendMentor.BlogPreviewCard.Factories.BlogAuthor;

/// <summary>
///     Creates the presentation models of blog authors.
/// </summary>
internal interface IBlogAuthorBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of a blog author.
    /// </summary>
    /// <param name="blogAuthor">The data of a blog author.</param>
    /// <returns>The presentation model.</returns>
    IBlogAuthorBindableModel Create(BlogAuthorModel blogAuthor);
}