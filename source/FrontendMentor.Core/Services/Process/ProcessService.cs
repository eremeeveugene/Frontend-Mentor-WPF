// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using System.Diagnostics;
using static System.Diagnostics.Process;

namespace FrontendMentor.Core.Services.Process;

internal class ProcessService : IProcessService
{
    public void StartProcess(string fileName)
    {
        Start(new ProcessStartInfo { FileName = fileName, UseShellExecute = true });
    }
}