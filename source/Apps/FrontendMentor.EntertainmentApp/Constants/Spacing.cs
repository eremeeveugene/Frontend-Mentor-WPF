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

using System.Windows;

namespace FrontendMentor.EntertainmentApp.Constants;

internal static class Spacing
{
    public const double Spacing100 = 8;
    public const double Spacing200 = 16;
    public const double Spacing300 = 24;
    public const double Spacing400 = 32;
    public const double Spacing500 = 40;
    public const double Spacing700 = 56;
    public const double Spacing900 = 72;
    public const double Spacing1000 = 80;

    public static Thickness Spacing300All = new(Spacing300);
}