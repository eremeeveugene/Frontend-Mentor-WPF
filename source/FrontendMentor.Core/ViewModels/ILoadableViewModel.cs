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

namespace FrontendMentor.Core.ViewModels;

/// <summary>
///     A view model that loads its data asynchronously once its view is shown.
/// </summary>
/// <remarks>
///     The view model only tells how its data is loaded. The <see cref="Services.ViewModelLoading.IViewModelLoadingService" />
///     decides when, and handles a load that fails.
/// </remarks>
public interface ILoadableViewModel : IViewModel
{
    /// <summary>
    ///     Loads the data of the view model.
    /// </summary>
    /// <param name="cancellationToken">The token that cancels the load.</param>
    /// <returns>A task that completes when the data is loaded.</returns>
    Task LoadAsync(CancellationToken cancellationToken);
}