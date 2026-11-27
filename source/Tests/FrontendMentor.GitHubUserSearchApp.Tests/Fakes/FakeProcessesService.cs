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

using FrontendMentor.Core.Services.Processes;

namespace FrontendMentor.GitHubUserSearchApp.Tests.Fakes;

/// <summary>
///     A processes service that only remembers what it was asked to open.
/// </summary>
internal sealed class FakeProcessesService : IProcessesService
{
    public List<string> StartedFileNames { get; } = [];

    public void StartProcess(string fileName)
    {
        StartedFileNames.Add(fileName);
    }
}