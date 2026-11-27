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
using FrontendMentor.Core.BindableModels;
using System.Windows.Media.Imaging;

namespace FrontendMentor.BlogPreviewCard.BindableModels.Blog;

/// <summary>
///     The presentation model of a blog.
/// </summary>
internal interface IBlogBindableModel : IBindableModel
{
    /// <summary>
    ///     Gets the title of the blog.
    /// </summary>
    string Title { get; }

    /// <summary>
    ///     Gets the description of the blog.
    /// </summary>
    string Description { get; }

    /// <summary>
    ///     Gets the category of the blog.
    /// </summary>
    string Category { get; }

    /// <summary>
    ///     Gets the date when the blog was published.
    /// </summary>
    DateTime PublishedDate { get; }

    /// <summary>
    ///     Gets the cover image of the blog, or <c>null</c> until it is loaded.
    /// </summary>
    BitmapImage? BlogImage { get; }

    /// <summary>
    ///     Gets the author of the blog.
    /// </summary>
    IBlogAuthorBindableModel BlogAuthor { get; }
}