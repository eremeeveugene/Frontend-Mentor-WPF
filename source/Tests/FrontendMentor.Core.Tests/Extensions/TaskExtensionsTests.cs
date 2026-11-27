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

using FrontendMentor.Core.Extensions;
using Microsoft.Extensions.Logging;

namespace FrontendMentor.Core.Tests.Extensions;

[TestClass]
public sealed class TaskExtensionsTests
{
    [TestMethod]
    public void Observe_FaultedTask_LogsTheError()
    {
        var logger = new RecordingLogger();
        var completion = new TaskCompletionSource();

        completion.Task.Observe(logger, "The work failed.");

        var exception = new InvalidOperationException("boom");

        completion.SetException(exception);

        Assert.AreEqual(1, logger.Entries.Count);
        Assert.AreEqual(LogLevel.Error, logger.Entries[0].Level);
        Assert.AreSame(exception, logger.Entries[0].Exception?.InnerException);
        Assert.Contains("The work failed.", logger.Entries[0].Message);
    }

    [TestMethod]
    public void Observe_SuccessfulTask_LogsNothing()
    {
        var logger = new RecordingLogger();

        Task.CompletedTask.Observe(logger, "The work failed.");

        Assert.AreEqual(0, logger.Entries.Count);
    }

    private sealed class RecordingLogger : ILogger
    {
        public List<(LogLevel Level, Exception? Exception, string Message)> Entries { get; } = [];

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            Entries.Add((logLevel, exception, formatter(state, exception)));
        }
    }
}