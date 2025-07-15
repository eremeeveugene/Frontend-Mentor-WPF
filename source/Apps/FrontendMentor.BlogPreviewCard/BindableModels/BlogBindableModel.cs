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

using FrontendMentor.BlogPreviewCard.Models;
using FrontendMentor.Core.Services.BitmapImages;
using System.Windows.Media.Imaging;

namespace FrontendMentor.BlogPreviewCard.BindableModels;

internal class BlogBindableModel : BindableBase
{
    public BlogBindableModel(IContainerProvider containerProvider,
        IBitmapImagesService bitmapImagesService,
        Parameters parameters)
    {
        Title = parameters.Blog.Title;
        Description = parameters.Blog.Description;
        Category = parameters.Blog.Category;
        PublishedDate = parameters.Blog.PublishedDate;
        BlogImage = bitmapImagesService.GetBitmapImageFromBase64String(parameters.Blog.ImageBase64String);
        BlogAuthor = BlogAuthorBindableModel.Create(containerProvider,
            new BlogAuthorBindableModel.Parameters(parameters.Blog.BlogAuthor));
    }

    public string Title { get; }

    public string Description { get; }

    public string Category { get; }

    public DateTime PublishedDate { get; }

    public BitmapImage BlogImage { get; }

    public BlogAuthorBindableModel BlogAuthor { get; }

    public static BlogBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<BlogBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(BlogModel Blog);
}