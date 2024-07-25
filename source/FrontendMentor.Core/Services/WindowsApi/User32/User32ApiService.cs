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

namespace FrontendMentor.Core.Services.WindowsApi.User32;

internal class User32ApiService : IUser32ApiService
{
    public void MinimizeWindow(IntPtr windowHandle)
    {
        User32Api.ShowWindow(windowHandle, (int)ShowWindowCommands.SW_MINIMIZE);
    }

    public void MaximizeWindow(IntPtr windowHandle)
    {
        User32Api.ShowWindow(windowHandle, (int)ShowWindowCommands.SW_MAXIMIZE);
    }
    public void ShowWindowNormal(IntPtr windowHandle)
    {
        User32Api.ShowWindow(windowHandle, (int)ShowWindowCommands.SW_NORMAL);
    }
}