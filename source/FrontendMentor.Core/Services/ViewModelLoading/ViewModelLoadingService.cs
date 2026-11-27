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
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace FrontendMentor.Core.Services.ViewModelLoading;

/// <inheritdoc />
/// <remarks>
///     The view models are used on the UI thread, so the state of the loads needs no synchronization. The state is
///     kept per view model without keeping the view model alive.
/// </remarks>
internal sealed class ViewModelLoadingService : IViewModelLoadingService
{
    private readonly ConditionalWeakTable<ILoadableViewModel, Load> _loads = new();
    private readonly ILogger<ViewModelLoadingService> _logger;

    public ViewModelLoadingService(ILogger<ViewModelLoadingService> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public Task LoadAsync(ILoadableViewModel viewModel, CancellationToken cancellationToken = default)
    {
        if (_loads.TryGetValue(viewModel, out var currentLoad) &&
            (currentLoad.IsLoaded ||
             (!currentLoad.Task.IsCompleted && !currentLoad.CancellationToken.IsCancellationRequested)))
        {
            return currentLoad.Task;
        }

        var load = new Load(cancellationToken);

        _loads.AddOrUpdate(viewModel, load);

        load.Task = LoadCoreAsync(viewModel, load, cancellationToken);

        return load.Task;
    }

    /// <summary>
    ///     Loads the data of a view model and logs the failure of the load, if any.
    /// </summary>
    /// <param name="viewModel">The view model.</param>
    /// <param name="load">The state of the load.</param>
    /// <param name="cancellationToken">The token that cancels the load.</param>
    /// <returns>
    ///     A task that completes when the load is done or failed, and that is canceled when
    ///     <paramref name="cancellationToken" /> cancels the load.
    /// </returns>
    private async Task LoadCoreAsync(ILoadableViewModel viewModel, Load load, CancellationToken cancellationToken)
    {
        try
        {
            await viewModel.LoadAsync(cancellationToken);

            load.IsLoaded = true;
        }
        catch (Exception exception) when (exception is not OperationCanceledException ||
                                          !cancellationToken.IsCancellationRequested)
        {
            _logger.LogError(exception, "Failed to load the data of {ViewModel}.", viewModel.GetType().Name);
        }
    }

    /// <summary>
    ///     The state of a load of a view model.
    /// </summary>
    private sealed class Load
    {
        public Load(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }

        /// <summary>
        ///     Gets the token that cancels the load.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether the data is loaded.
        /// </summary>
        public bool IsLoaded { get; set; }

        /// <summary>
        ///     Gets or sets the task of the load.
        /// </summary>
        public Task Task { get; set; } = Task.CompletedTask;
    }
}