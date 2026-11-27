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

using FrontendMentor.Core.BindableModels;
using System.Windows.Media.Imaging;

namespace FrontendMentor.BlogPreviewCard.BindableModels.BlogAuthor;

/// <summary>
///     The presentation model of a blog author.
/// </summary>
internal interface IBlogAuthorBindableModel : IBindableModel
{
    /// <summary>
    ///     Gets the first name of the author.
    /// </summary>
    string FirstName { get; }

    /// <summary>
    ///     Gets the last name of the author.
    /// </summary>
    string LastName { get; }

    /// <summary>
    ///     Gets the photo of the author, or <c>null</c> until it is loaded.
    /// </summary>
    BitmapImage? UserImage { get; }
}