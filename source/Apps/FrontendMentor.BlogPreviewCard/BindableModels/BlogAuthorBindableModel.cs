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

internal class BlogAuthorBindableModel(
    IBitmapImagesService bitmapImagesService,
    BlogAuthorBindableModel.Parameters parameters) : BindableBase
{
    public string FirstName { get; } = parameters.BlogAuthor.FirstName;
    public string LastName { get; } = parameters.BlogAuthor.LastName;

    public BitmapImage UserImage { get; } =
        bitmapImagesService.GetBitmapImageFromBase64String(parameters.BlogAuthor.ImageBase64String);

    public static BlogAuthorBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<BlogAuthorBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(BlogAuthorModel BlogAuthor);
}