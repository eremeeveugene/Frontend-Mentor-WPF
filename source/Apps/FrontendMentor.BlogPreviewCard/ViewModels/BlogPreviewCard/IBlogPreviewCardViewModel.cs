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
using FrontendMentor.Core.ViewModels;

namespace FrontendMentor.BlogPreviewCard.ViewModels.BlogPreviewCard;

/// <summary>
///     The view model of the blog preview card.
/// </summary>
internal interface IBlogPreviewCardViewModel : IViewModel
{
    /// <summary>
    ///     Gets the blog that the card shows.
    /// </summary>
    IBlogBindableModel Blog { get; }
}