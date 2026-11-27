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

namespace FrontendMentor.Core.Services.UnhandledExceptions;

/// <summary>
///     Handles the exceptions that nothing else handled.
/// </summary>
public interface IUnhandledExceptionsService
{
    /// <summary>
    ///     Logs an exception of the UI thread and tells the user that an error occurred.
    /// </summary>
    /// <param name="exception">The exception.</param>
    void HandleUserInterfaceException(Exception exception);

    /// <summary>
    ///     Logs an exception of a background thread or of a task that nothing observed.
    /// </summary>
    /// <param name="exception">The exception.</param>
    void LogBackgroundException(Exception exception);
}