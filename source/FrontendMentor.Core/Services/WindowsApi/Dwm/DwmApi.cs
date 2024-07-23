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

using System.Runtime.InteropServices;

namespace FrontendMentor.Core.Services.WindowsApi.Dwm;

internal static class DwmApi
{
    private const string DwmApiDllName = "dwmapi.dll";

    [DllImport(DwmApiDllName, CharSet = CharSet.Unicode, SetLastError = true)]
    internal static extern long DwmSetWindowAttribute(IntPtr windowHandle, int attribute, ref int pvAttribute,
        uint cbAttribute);
}