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

namespace FrontendMentor.Core.Services.WindowsVersion;

internal class WindowsVersionService : IWindowsVersionService
{
    public bool IsWindows10OrHigher()
    {
        return IsWindowsVersionOrGreater(10, 0, 0);
    }

    public bool IsWindows11OrHigher()
    {
        return IsWindowsVersionOrGreater(10, 0, 22000);
    }

    public bool IsWindowsVersionOrGreater(int major, int minor, int build)
    {
        var osVersion = Environment.OSVersion;

        return osVersion.Platform == PlatformID.Win32NT &&
               (osVersion.Version.Major > major ||
                (osVersion.Version.Major == major && osVersion.Version.Minor > minor) ||
                (osVersion.Version.Major == major && osVersion.Version.Minor == minor &&
                 osVersion.Version.Build >= build));
    }

    public bool IsWindows7OrHigher()
    {
        return IsWindowsVersionOrGreater(6, 1, 0);
    }
}