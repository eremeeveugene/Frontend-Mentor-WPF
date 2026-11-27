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
using FrontendMentor.Core.Views;
using System.ComponentModel;
using System.Windows;

namespace FrontendMentor.Core.Tests.Views;

[TestClass]
public sealed class ViewLoadingHandlerTests
{
    private ViewLoadingHandler _handler = null!;
    private SpyViewModelLoadingService _viewModelLoadingService = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _viewModelLoadingService = new SpyViewModelLoadingService();
        _handler = new ViewLoadingHandler(_viewModelLoadingService);
    }

    [STATestMethod]
    public void Loaded_LoadableViewModel_LoadsItsData()
    {
        var viewModel = new LoadableViewModel();
        var view = new TestView(viewModel);

        RaiseLoaded(view);

        Assert.HasCount(1, _viewModelLoadingService.Loads);
        Assert.AreSame(viewModel, _viewModelLoadingService.Loads[0].ViewModel);
        Assert.IsFalse(_viewModelLoadingService.Loads[0].CancellationToken.IsCancellationRequested);
    }

    [STATestMethod]
    public void Loaded_WhileLoading_DoesNotStartASecondLoad()
    {
        var view = new TestView(new LoadableViewModel());

        RaiseLoaded(view);
        RaiseLoaded(view);

        Assert.HasCount(1, _viewModelLoadingService.Loads);
    }

    [STATestMethod]
    public void Unloaded_WhileLoading_CancelsTheLoad()
    {
        var view = new TestView(new LoadableViewModel());

        RaiseLoaded(view);
        RaiseUnloaded(view);

        var (completion, _, cancellationToken) = _viewModelLoadingService.Loads[0];

        Assert.IsTrue(cancellationToken.IsCancellationRequested);

        // The canceled load ends without an exception, which would otherwise reach the dispatcher.
        completion.SetCanceled(cancellationToken);
    }

    [STATestMethod]
    public void Loaded_AfterACanceledLoad_LoadsAgain()
    {
        var view = new TestView(new LoadableViewModel());

        RaiseLoaded(view);
        RaiseUnloaded(view);
        RaiseLoaded(view);

        Assert.HasCount(2, _viewModelLoadingService.Loads);
        Assert.IsFalse(_viewModelLoadingService.Loads[1].CancellationToken.IsCancellationRequested);
    }

    [STATestMethod]
    public void Unloaded_AfterTheDataIsLoaded_DoesNotCancelIt()
    {
        var view = new TestView(new LoadableViewModel());

        RaiseLoaded(view);
        _viewModelLoadingService.Loads[0].Completion.SetResult();
        RaiseUnloaded(view);

        Assert.IsFalse(_viewModelLoadingService.Loads[0].CancellationToken.IsCancellationRequested);
    }

    [STATestMethod]
    public void Loaded_ViewModelThatIsNotLoadable_DoesNothing()
    {
        var view = new TestView(new PlainViewModel());

        RaiseLoaded(view);
        RaiseUnloaded(view);

        Assert.IsEmpty(_viewModelLoadingService.Loads);
    }

    private void RaiseLoaded(FrameworkElement view)
    {
        _handler.OnLoaded(view, new RoutedEventArgs(FrameworkElement.LoadedEvent, view));
    }

    private void RaiseUnloaded(FrameworkElement view)
    {
        _handler.OnUnloaded(view, new RoutedEventArgs(FrameworkElement.UnloadedEvent, view));
    }

    private sealed class TestView(IViewModel viewModel) : ViewBase(viewModel);

    /// <summary>
    ///     A loading service whose loads complete only when a test completes them.
    /// </summary>
    private sealed class SpyViewModelLoadingService : IViewModelLoadingService
    {
        public List<Load> Loads { get; } = [];

        public Task LoadAsync(ILoadableViewModel viewModel, CancellationToken cancellationToken = default)
        {
            var completion = new TaskCompletionSource();

            Loads.Add(new Load(completion, viewModel, cancellationToken));

            return completion.Task;
        }
    }

    /// <summary>
    ///     A load that the loading service started.
    /// </summary>
    private sealed record Load(
        TaskCompletionSource Completion,
        ILoadableViewModel ViewModel,
        CancellationToken CancellationToken);

    private sealed class LoadableViewModel : ILoadableViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged
        {
            add { }
            remove { }
        }

        public Task LoadAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    private sealed class PlainViewModel : IViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged
        {
            add { }
            remove { }
        }
    }
}