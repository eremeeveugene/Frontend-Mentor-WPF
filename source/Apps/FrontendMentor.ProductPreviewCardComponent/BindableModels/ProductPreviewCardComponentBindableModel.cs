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

using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.ProductPreviewCardComponent.Models;
using System.Windows.Media.Imaging;

namespace FrontendMentor.ProductPreviewCardComponent.BindableModels;

internal class ProductPreviewCardComponentBindableModel(
    IBitmapImagesService bitmapImagesService,
    ProductPreviewCardComponentBindableModel.Parameters parameters) : BindableBase
{
    public string Type
    {
        get;
    } = parameters.Product.Type;

    public string Title
    {
        get;
    } = parameters.Product.Title;

    public string Description
    {
        get;
    } = parameters.Product.Description;

    public double Price
    {
        get;
    } = parameters.Product.Price;

    public double OldPrice
    {
        get;
    } = parameters.Product.OldPrice;

    public BitmapImage ProfileImage
    {
        get;
    } = bitmapImagesService.GetBitmapImageFromBase64String(parameters.Product.ProductImageBase64String);

    public static ProductPreviewCardComponentBindableModel Create(IContainerProvider containerProvider,
        Parameters parameters)
    {
        return containerProvider.Resolve<ProductPreviewCardComponentBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(ProductModel Product);
}