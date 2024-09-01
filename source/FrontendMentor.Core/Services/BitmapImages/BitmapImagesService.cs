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

using System.IO;
using System.Windows.Media.Imaging;

namespace FrontendMentor.Core.Services.BitmapImages;

internal class BitmapImagesService : IBitmapImagesService
{
    public BitmapImage GetBitmapImage(Uri uri)
    {
        var bitmapImage = new BitmapImage(uri);

        bitmapImage.Freeze();

        return bitmapImage;
    }

    public BitmapImage GetBitmapImage(string uriString)
    {
        return GetBitmapImage(new Uri(uriString, UriKind.RelativeOrAbsolute));
    }

    public BitmapImage GetBitmapImageFromBase64String(string base64String)
    {
        var imageBytes = Convert.FromBase64String(base64String);

        using var memoryStream = new MemoryStream(imageBytes);

        var bitmapImage = new BitmapImage();

        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = memoryStream;
        bitmapImage.EndInit();
        bitmapImage.Freeze();

        return bitmapImage;
    }
}