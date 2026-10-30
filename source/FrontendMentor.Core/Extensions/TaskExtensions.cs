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

using Microsoft.Extensions.Logging;

namespace FrontendMentor.Core.Extensions;

/// <summary>
///     Extension methods for <see cref="Task" />.
/// </summary>
public static class TaskExtensions
{
    /// <summary>
    ///     Observes a task that nobody awaits, so that its failure is logged and not lost.
    /// </summary>
    /// <param name="task">The task to observe.</param>
    /// <param name="logger">The logger that records the failure.</param>
    /// <param name="message">The message that describes the work of the task.</param>
    public static void Observe(this Task task, ILogger logger, string message)
    {
        if (task.IsCompletedSuccessfully)
        {
            return;
        }

        task.ContinueWith(
            completedTask => logger.LogError(completedTask.Exception, "{Message}", message),
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }
}