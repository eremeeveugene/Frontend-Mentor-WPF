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
using System.Windows.Media;

namespace FrontendMentor.Core.Services.WindowsApi.Dwm;

[StructLayout(LayoutKind.Sequential)]
internal struct DwmApiColor(Color color)
{
    public int ColorDWORD = color.R + (color.G << 8) + (color.B << 16);

    public Color GetColor()
    {
        return Color.FromRgb((byte)(0x000000FFU & ColorDWORD), (byte)((0x0000FF00U & ColorDWORD) >> 8),
            (byte)((0x00FF0000U & ColorDWORD) >> 16));
    }

    public void SetColor(Color color)
    {
        ColorDWORD = color.R + (color.G << 8) + (color.B << 16);
    }
}