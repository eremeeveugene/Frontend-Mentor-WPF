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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.ProductPreviewCardComponent.BindableModels;
using FrontendMentor.ProductPreviewCardComponent.Services.Products;

namespace FrontendMentor.ProductPreviewCardComponent.ViewModels;

internal sealed class ProductPreviewCardComponentViewModel(
    IContainerProvider containerProvider,
    IProductsService productsService) : NavigationViewModelBase
{
    private ProductPreviewCardComponentBindableModel _product = null!;

    public ProductPreviewCardComponentBindableModel Product
    {
        get => _product;
        private set => SetProperty(ref _product, value);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        var product = productsService.GetProduct();

        Product = ProductPreviewCardComponentBindableModel.Create(containerProvider,
            new ProductPreviewCardComponentBindableModel.Parameters(product));
    }
}