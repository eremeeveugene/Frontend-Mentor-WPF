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

using FrontendMentor.ProductPreviewCardComponent.Constants;
using FrontendMentor.ProductPreviewCardComponent.Controls.Windows;
using FrontendMentor.ProductPreviewCardComponent.Services.Products;
using FrontendMentor.ProductPreviewCardComponent.Views;
using System.Windows;

namespace FrontendMentor.ProductPreviewCardComponent;

internal partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<ProductPreviewCardComponentWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterSingleton<IProductsService, ProductsService>();
        containerRegistry.RegisterForNavigation<ProductPreviewCardComponentView>(ProductPreviewCardComponentViewNames
            .ProductPreviewCardComponent);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigateToShellRegion(ProductPreviewCardComponentViewNames.ProductPreviewCardComponent);
    }
}