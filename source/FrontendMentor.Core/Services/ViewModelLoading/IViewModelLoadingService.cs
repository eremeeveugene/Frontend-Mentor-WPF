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

namespace FrontendMentor.Core.Services.ViewModelLoading;

/// <summary>
///     Loads the data of view models.
/// </summary>
public interface IViewModelLoadingService
{
    /// <summary>
    ///     Loads the data of a view model. A load that is running or has completed is shared by later calls, so the
    ///     data is loaded once. A load that was canceled or failed is started again by the next call.
    /// </summary>
    /// <param name="viewModel">The view model.</param>
    /// <param name="cancellationToken">The token that cancels the load, such as when the view is closed.</param>
    /// <returns>
    ///     A task that completes when the data is loaded or the load failed. A failed load is logged and does not fail
    ///     the task. The task is canceled only when <paramref name="cancellationToken" /> cancels the load.
    /// </returns>
    Task LoadAsync(ILoadableViewModel viewModel, CancellationToken cancellationToken = default);
}