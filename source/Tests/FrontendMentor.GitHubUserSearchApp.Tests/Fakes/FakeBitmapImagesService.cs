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

using FrontendMentor.Core.Services.BitmapImages;
using System.IO;
using System.Windows.Media.Imaging;

namespace FrontendMentor.GitHubUserSearchApp.Tests.Fakes;

/// <summary>
///     A bitmap images service that records the requested URLs and returns the same small image.
/// </summary>
internal sealed class FakeBitmapImagesService : IBitmapImagesService
{
    public static BitmapImage Image { get; } = CreateImage();

    public List<(Uri Url, int DecodePixelWidth)> UrlRequests { get; } = [];

    public Exception? ExceptionToThrow { get; set; }

    public Task<BitmapImage> GetBitmapImageFromBase64StringAsync(string base64String,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Image);
    }

    public Task<BitmapImage> GetBitmapImageFromUrlAsync(Uri url, int decodePixelWidth,
        CancellationToken cancellationToken = default)
    {
        UrlRequests.Add((url, decodePixelWidth));

        return ExceptionToThrow == null ? Task.FromResult(Image) : Task.FromException<BitmapImage>(ExceptionToThrow);
    }

    private static BitmapImage CreateImage()
    {
        using var memoryStream = new MemoryStream(Convert.FromBase64String(
            "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg=="));

        var bitmapImage = new BitmapImage();

        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = memoryStream;
        bitmapImage.EndInit();
        bitmapImage.Freeze();

        return bitmapImage;
    }
}