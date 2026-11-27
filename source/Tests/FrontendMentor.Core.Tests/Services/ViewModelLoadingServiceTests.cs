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
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace FrontendMentor.Core.Tests.Services;

[TestClass]
public sealed class ViewModelLoadingServiceTests
{
    private FakeLogger _logger = null!;
    private ViewModelLoadingService _service = null!;
    private SpyViewModel _viewModel = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _logger = new FakeLogger();
        _service = new ViewModelLoadingService(_logger);
        _viewModel = new SpyViewModel();
    }

    [TestMethod]
    public void LoadAsync_PassesTheTokenToTheViewModel()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        _ = _service.LoadAsync(_viewModel, cancellationTokenSource.Token);

        Assert.AreEqual(cancellationTokenSource.Token, _viewModel.Loads[0].CancellationToken);
    }

    [TestMethod]
    public void LoadAsync_WhileLoading_SharesTheRunningLoad()
    {
        var firstTask = _service.LoadAsync(_viewModel);
        var secondTask = _service.LoadAsync(_viewModel);

        Assert.HasCount(1, _viewModel.Loads);
        Assert.AreSame(firstTask, secondTask);
    }

    [TestMethod]
    public void LoadAsync_DifferentViewModels_LoadEach()
    {
        var otherViewModel = new SpyViewModel();

        _ = _service.LoadAsync(_viewModel);
        _ = _service.LoadAsync(otherViewModel);

        Assert.HasCount(1, _viewModel.Loads);
        Assert.HasCount(1, otherViewModel.Loads);
    }

    [TestMethod]
    public async Task LoadAsync_AfterTheDataIsLoaded_DoesNotLoadItAgain()
    {
        var firstTask = _service.LoadAsync(_viewModel);
        _viewModel.Loads[0].Completion.SetResult();
        await firstTask;

        var secondTask = _service.LoadAsync(_viewModel);

        Assert.HasCount(1, _viewModel.Loads);
        Assert.IsTrue(secondTask.IsCompletedSuccessfully);
    }

    [TestMethod]
    public async Task LoadAsync_FailedLoad_IsLoggedAndDoesNotFail()
    {
        var exception = new InvalidOperationException();

        var task = _service.LoadAsync(_viewModel);
        _viewModel.Loads[0].Completion.SetException(exception);
        await task;

        Assert.HasCount(1, _logger.Entries);
        Assert.AreEqual(LogLevel.Error, _logger.Entries[0].LogLevel);
        Assert.AreSame(exception, _logger.Entries[0].Exception);
    }

    [TestMethod]
    public async Task LoadAsync_AfterAFailedLoad_LoadsAgain()
    {
        var task = _service.LoadAsync(_viewModel);
        _viewModel.Loads[0].Completion.SetException(new InvalidOperationException());
        await task;

        _ = _service.LoadAsync(_viewModel);

        Assert.HasCount(2, _viewModel.Loads);
    }

    [TestMethod]
    public async Task LoadAsync_LoadCanceledByTheCaller_IsCanceledWithoutLoggingAndLoadsAgain()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        var task = _service.LoadAsync(_viewModel, cancellationTokenSource.Token);
        await cancellationTokenSource.CancelAsync();
        _viewModel.Loads[0].Completion.SetCanceled(cancellationTokenSource.Token);

        await Assert.ThrowsAsync<OperationCanceledException>(() => task);

        _ = _service.LoadAsync(_viewModel);

        Assert.IsEmpty(_logger.Entries);
        Assert.HasCount(2, _viewModel.Loads);
    }

    [TestMethod]
    public async Task LoadAsync_LoadCanceledByAnotherToken_IsLoggedAndDoesNotFail()
    {
        var task = _service.LoadAsync(_viewModel);
        _viewModel.Loads[0].Completion.SetCanceled();
        await task;

        Assert.HasCount(1, _logger.Entries);
    }

    [TestMethod]
    public void LoadAsync_WhileTheRunningLoadIsCanceled_StartsANewLoad()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        _ = _service.LoadAsync(_viewModel, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        _ = _service.LoadAsync(_viewModel);

        Assert.HasCount(2, _viewModel.Loads, "The canceled load may still be running, but it must not be shared.");
    }

    /// <summary>
    ///     A view model whose loads complete only when a test completes them.
    /// </summary>
    private sealed class SpyViewModel : ILoadableViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged
        {
            add { }
            remove { }
        }

        public List<(TaskCompletionSource Completion, CancellationToken CancellationToken)> Loads { get; } = [];

        public Task LoadAsync(CancellationToken cancellationToken)
        {
            var completion = new TaskCompletionSource();

            Loads.Add((completion, cancellationToken));

            return completion.Task;
        }
    }

    /// <summary>
    ///     A logger that records its entries.
    /// </summary>
    private sealed class FakeLogger : ILogger<ViewModelLoadingService>
    {
        public List<(LogLevel LogLevel, Exception? Exception)> Entries { get; } = [];

        public IDisposable? BeginScope<TState>(TState state)
            where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            Entries.Add((logLevel, exception));
        }
    }
}