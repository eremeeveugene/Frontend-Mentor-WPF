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

using FrontendMentor.Core.ViewModels;
using System.Windows.Controls;

namespace FrontendMentor.Core.Views;

/// <summary>
///     The base of views. It binds to its view model.
/// </summary>
/// <remarks>
///     When the view model is an <see cref="ILoadableViewModel" />, the application loads its data when the view is
///     loaded.
/// </remarks>
public abstract class ViewBase : UserControl, IView
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ViewBase" /> class.
    /// </summary>
    /// <param name="viewModel">The view model that the view binds to.</param>
    protected ViewBase(IViewModel viewModel)
    {
        DataContext = viewModel;
    }
}