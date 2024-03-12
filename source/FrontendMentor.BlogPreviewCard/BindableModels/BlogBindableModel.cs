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
using Prism.Ioc;
using Prism.Mvvm;
using System.Windows.Media.Imaging;

namespace FrontendMentor.BlogPreviewCard.BindableModels;

internal class BlogBindableModel(IBitmapImagesService bitmapImagesService, BlogModel blogModel)
    : BindableBase
{
    private readonly Lazy<BitmapSource> _userImage = new(() => bitmapImagesService.GetBitmapImage(blogModel.BlogAuthor.ImageUriString));

    public string Title => blogModel.Title;
    public string Description => blogModel.Description;
    public string Category => blogModel.Category;
    public DateTime PublishedDate => blogModel.PublishedDate;
    public string FirstName => blogModel.BlogAuthor.FirstName;
    public string LastName => blogModel.BlogAuthor.LastName;
    public BitmapSource UserImage => _userImage.Value;

    public static BlogBindableModel Create(IContainerProvider containerProvider, BlogModel blogModel)
    {
        return containerProvider.Resolve<BlogBindableModel>((typeof(BlogModel), blogModel));
    }
}