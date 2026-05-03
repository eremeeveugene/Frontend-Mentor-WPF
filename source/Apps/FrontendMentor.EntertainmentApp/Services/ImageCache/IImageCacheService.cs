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

using System.Diagnostics.CodeAnalysis;
using System.Windows.Media.Imaging;

namespace FrontendMentor.EntertainmentApp.Services.ImageCache;

internal interface IImageCacheService
{
    bool TryGet(string url, [MaybeNullWhen(false)] out BitmapSource bitmapSource);

    void Set(string url, BitmapSource bitmapSource);
}