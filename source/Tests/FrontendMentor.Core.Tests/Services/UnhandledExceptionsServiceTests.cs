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

using FrontendMentor.Core.Services.Messages;
using FrontendMentor.Core.Services.UnhandledExceptions;
using Microsoft.Extensions.Logging;

namespace FrontendMentor.Core.Tests.Services;

[TestClass]
public sealed class UnhandledExceptionsServiceTests
{
    [TestMethod]
    public void HandleUserInterfaceException_LogsTheExceptionAndTellsTheUser()
    {
        var logger = new FakeLogger();
        var messagesService = new FakeMessagesService();
        var service = new UnhandledExceptionsService(logger, messagesService);
        var exception = new InvalidOperationException();

        service.HandleUserInterfaceException(exception);

        CollectionAssert.AreEqual(new Exception[] { exception }, logger.Exceptions);
        Assert.AreEqual(1, messagesService.ErrorCount);
    }

    [TestMethod]
    public void HandleUserInterfaceException_WhileAMessageIsOpen_OnlyLogs()
    {
        var logger = new FakeLogger();
        var messagesService = new FakeMessagesService();
        var service = new UnhandledExceptionsService(logger, messagesService);

        messagesService.WhileShowing = () => service.HandleUserInterfaceException(new InvalidOperationException());

        service.HandleUserInterfaceException(new InvalidOperationException());

        Assert.AreEqual(2, logger.Exceptions.Count);
        Assert.AreEqual(1, messagesService.ErrorCount);
    }

    [TestMethod]
    public void HandleUserInterfaceException_AfterTheMessageIsClosed_TellsTheUserAgain()
    {
        var messagesService = new FakeMessagesService();
        var service = new UnhandledExceptionsService(new FakeLogger(), messagesService);

        service.HandleUserInterfaceException(new InvalidOperationException());
        service.HandleUserInterfaceException(new InvalidOperationException());

        Assert.AreEqual(2, messagesService.ErrorCount);
    }

    [TestMethod]
    public void LogBackgroundException_LogsWithoutAMessage()
    {
        var logger = new FakeLogger();
        var messagesService = new FakeMessagesService();
        var service = new UnhandledExceptionsService(logger, messagesService);

        service.LogBackgroundException(new InvalidOperationException());

        Assert.AreEqual(1, logger.Exceptions.Count);
        Assert.AreEqual(0, messagesService.ErrorCount);
    }

    private sealed class FakeMessagesService : IMessagesService
    {
        public int ErrorCount { get; private set; }

        public Action? WhileShowing { get; set; }

        public void ShowError(string title, string message)
        {
            ErrorCount++;

            var whileShowing = WhileShowing;
            WhileShowing = null;
            whileShowing?.Invoke();
        }
    }

    private sealed class FakeLogger : ILogger<UnhandledExceptionsService>
    {
        public List<Exception?> Exceptions { get; } = [];

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
            Exceptions.Add(exception);
        }
    }
}