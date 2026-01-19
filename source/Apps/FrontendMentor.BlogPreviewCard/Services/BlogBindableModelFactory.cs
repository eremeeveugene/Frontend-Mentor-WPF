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

using FrontendMentor.BlogPreviewCard.BindableModels;

namespace FrontendMentor.BlogPreviewCard.Services;

internal sealed class BlogBindableModelFactory : IBlogBindableModelFactory
{
    private readonly Func<BlogBindableModel.Parameters, BlogBindableModel> _factory;

    public BlogBindableModelFactory(
        Func<BlogBindableModel.Parameters, BlogBindableModel> factory)
    {
        _factory = factory;
    }

    public BlogBindableModel Create(BlogBindableModel.Parameters parameters)
    {
        return _factory(parameters);
    }
}