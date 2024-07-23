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

using FrontendMentor.Core.Services.WindowsVersion;
using System.Windows.Media;

namespace FrontendMentor.Core.Services.WindowsApi.Dwm;

internal class DwmApiService(IWindowsVersionService windowsVersionService) : IDwmApiService
{
    public bool SetWindowCaptionColor(nint windowHandle, Color color)
    {
        if (!windowsVersionService.IsWindows11OrHigher())
        {
            return false;
        }

        var dwmApiColor = new DwmApiColor(color).ColorDWORD;

        var result = DwmApi.DwmSetWindowAttribute(windowHandle,
            (int)DwmApiWindowAttribute.DWMWA_CAPTION_COLOR,
            ref dwmApiColor, sizeof(uint));

        return result == 0;
    }
}