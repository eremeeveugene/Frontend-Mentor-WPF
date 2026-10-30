// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

namespace FrontendMentor.Core.Services.Processes;

/// <summary>
///     Starts operating system processes.
/// </summary>
public interface IProcessesService
{
    /// <summary>
    ///     Starts a process, or opens a document or a link, with the shell.
    /// </summary>
    /// <param name="fileName">The file name, document or link to open.</param>
    void StartProcess(string fileName);
}