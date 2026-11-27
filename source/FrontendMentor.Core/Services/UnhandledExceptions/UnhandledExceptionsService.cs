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

using FrontendMentor.Core.Properties;
using FrontendMentor.Core.Services.Messages;
using Microsoft.Extensions.Logging;

namespace FrontendMentor.Core.Services.UnhandledExceptions;

/// <inheritdoc />
internal sealed class UnhandledExceptionsService : IUnhandledExceptionsService
{
    private readonly ILogger<UnhandledExceptionsService> _logger;
    private readonly IMessagesService _messagesService;
    private bool _isShowingMessage;

    public UnhandledExceptionsService(ILogger<UnhandledExceptionsService> logger, IMessagesService messagesService)
    {
        _logger = logger;
        _messagesService = messagesService;
    }

    /// <inheritdoc />
    public void HandleUserInterfaceException(Exception exception)
    {
        _logger.LogCritical(exception, "An exception of the UI thread was not handled.");

        // The UI thread keeps working while a message is open, so another exception must not open a second one.
        if (_isShowingMessage)
        {
            return;
        }

        _isShowingMessage = true;

        try
        {
            _messagesService.ShowError(Resources.UnhandledException_Title, Resources.UnhandledException_Message);
        }
        finally
        {
            _isShowingMessage = false;
        }
    }

    /// <inheritdoc />
    public void LogBackgroundException(Exception exception)
    {
        _logger.LogCritical(exception, "An exception of a background operation was not handled.");
    }
}