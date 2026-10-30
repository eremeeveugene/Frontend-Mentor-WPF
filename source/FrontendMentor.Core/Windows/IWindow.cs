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

namespace FrontendMentor.Core.Windows;

/// <summary>
///     A window of the application.
/// </summary>
public interface IWindow
{
    /// <summary>
    ///     Opens the window and returns without waiting for it to close.
    /// </summary>
    void Show();

    /// <summary>
    ///     Closes the window.
    /// </summary>
    void Close();
}