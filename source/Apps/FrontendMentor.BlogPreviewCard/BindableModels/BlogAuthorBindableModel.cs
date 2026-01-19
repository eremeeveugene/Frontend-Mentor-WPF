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

internal class BlogAuthorBindableModel 
{
    public BlogAuthorBindableModel(IBitmapImagesService bitmapImagesService,
        BlogAuthorBindableModel.Parameters parameters)
    {
        FirstName = parameters.BlogAuthor.FirstName;
        LastName = parameters.BlogAuthor.LastName;
        UserImage = bitmapImagesService.GetBitmapImageFromBase64String(parameters.BlogAuthor.ImageBase64String);
    }

    public string FirstName
    {
        get;
    }

    public string LastName
    {
        get;
    }

    public BitmapImage UserImage
    {
        get;
    }

    public record Parameters(BlogAuthorModel BlogAuthor);
}