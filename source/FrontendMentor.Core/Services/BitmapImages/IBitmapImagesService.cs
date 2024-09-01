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

using System.Windows.Media.Imaging;

namespace FrontendMentor.Core.Services.BitmapImages;

public interface IBitmapImagesService
{
    BitmapImage GetBitmapImage(Uri uri);
    BitmapImage GetBitmapImage(string uriString);
    BitmapImage GetBitmapImageFromBase64String(string base64String);
}