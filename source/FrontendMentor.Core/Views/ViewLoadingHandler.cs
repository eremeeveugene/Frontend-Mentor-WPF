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

using FrontendMentor.Core.Services.ViewModelLoading;
using FrontendMentor.Core.ViewModels;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FrontendMentor.Core.Views;

/// <summary>
///     Loads the data of the view model of a view when the view is loaded, and cancels the load when the view is
///     unloaded first.
/// </summary>
/// <remarks>
///     The application registers it once for all views, so a view needs no dependency to load its data.
///     A view model belongs to one view, so only that view starts and cancels its load.
/// </remarks>
internal sealed class ViewLoadingHandler
{
    private readonly ConditionalWeakTable<FrameworkElement, CancellationTokenSource> _cancellationTokenSources = new();
    private readonly IViewModelLoadingService _viewModelLoadingService;

    public ViewLoadingHandler(IViewModelLoadingService viewModelLoadingService)
    {
        _viewModelLoadingService = viewModelLoadingService;
    }

    /// <summary>
    ///     Registers the handler for all views of the application.
    /// </summary>
    /// <remarks>
    ///     A registration cannot be removed, so it is done once, when the application starts.
    /// </remarks>
    public void RegisterForAllViews()
    {
        EventManager.RegisterClassHandler(typeof(ViewBase), FrameworkElement.LoadedEvent, new RoutedEventHandler(OnLoaded));
        EventManager.RegisterClassHandler(typeof(ViewBase), FrameworkElement.UnloadedEvent, new RoutedEventHandler(OnUnloaded));
    }

    /// <summary>
    ///     Loads the data of the view model of the view, unless a load of this view is still running.
    /// </summary>
    /// <param name="sender">The view.</param>
    /// <param name="e">The event data.</param>
    internal async void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is not FrameworkElement { DataContext: ILoadableViewModel viewModel } view ||
            (_cancellationTokenSources.TryGetValue(view, out var runningCancellationTokenSource) &&
             !runningCancellationTokenSource.IsCancellationRequested))
        {
            return;
        }

        using var cancellationTokenSource = new CancellationTokenSource();

        _cancellationTokenSources.AddOrUpdate(view, cancellationTokenSource);

        try
        {
            await _viewModelLoadingService.LoadAsync(viewModel, cancellationTokenSource.Token);
        }
        catch (OperationCanceledException) when (cancellationTokenSource.IsCancellationRequested)
        {
            // The view was unloaded first. The data is loaded again the next time the view is loaded.
        }
        finally
        {
            if (_cancellationTokenSources.TryGetValue(view, out var currentCancellationTokenSource) &&
                currentCancellationTokenSource == cancellationTokenSource)
            {
                _cancellationTokenSources.Remove(view);
            }
        }
    }

    /// <summary>
    ///     Cancels the load of the view that is still running, if any.
    /// </summary>
    /// <param name="sender">The view.</param>
    /// <param name="e">The event data.</param>
    internal void OnUnloaded(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement view &&
            _cancellationTokenSources.TryGetValue(view, out var cancellationTokenSource))
        {
            cancellationTokenSource.Cancel();
        }
    }
}