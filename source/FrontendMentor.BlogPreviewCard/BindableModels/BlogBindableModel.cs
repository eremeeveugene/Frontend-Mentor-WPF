// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
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

internal class BlogBindableModel(
    IContainerProvider containerProvider,
    IBitmapImageService bitmapImagesService,
    BlogBindableModel.Parameters parameters)
    : BindableBase
{
    public string Title { get; } = parameters.Blog.Title;
    public string Description { get; } = parameters.Blog.Description;
    public string Category { get; } = parameters.Blog.Category;
    public DateTime PublishedDate { get; } = parameters.Blog.PublishedDate;

    public BitmapImage BlogImage { get; } =
        bitmapImagesService.GetBitmapImageFromBase64String(parameters.Blog.ImageBase64String);

    public BlogAuthorBindableModel BlogAuthor { get; } = BlogAuthorBindableModel.Create(containerProvider,
        new BlogAuthorBindableModel.Parameters(parameters.Blog.BlogAuthor));

    public static BlogBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<BlogBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(BlogModel Blog);
}