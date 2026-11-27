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

namespace FrontendMentor.Core.Services.Messages;

/// <summary>
///     Shows messages to the user.
/// </summary>
public interface IMessagesService
{
    /// <summary>
    ///     Shows an error message and waits until the user closes it.
    /// </summary>
    /// <param name="title">The title of the message.</param>
    /// <param name="message">The text of the message.</param>
    void ShowError(string title, string message);
}