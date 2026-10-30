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

using FrontendMentor.BlogPreviewCard.ViewModels.BlogPreviewCard;

namespace FrontendMentor.BlogPreviewCard.Views.BlogPreviewCard;

/// <inheritdoc cref="IBlogPreviewCardView" />
internal sealed partial class BlogPreviewCardView : IBlogPreviewCardView
{
    public BlogPreviewCardView(IBlogPreviewCardViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}