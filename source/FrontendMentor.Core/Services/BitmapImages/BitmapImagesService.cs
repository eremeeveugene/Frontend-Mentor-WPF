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

using FrontendMentor.Core.Services.Cache;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Media.Imaging;

namespace FrontendMentor.Core.Services.BitmapImages;

/// <inheritdoc />
internal sealed class BitmapImagesService : IBitmapImagesService
{
    private const string CacheKeyFormat = $"{nameof(BitmapImagesService)}:{{0}}";

    private readonly ICacheService _cacheService;

    public BitmapImagesService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    /// <inheritdoc />
    public Task<BitmapImage> GetBitmapImageFromBase64StringAsync(string base64String, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => GetBitmapImageFromBase64String(base64String), cancellationToken);
    }

    /// <summary>
    ///     Gets a frozen bitmap image from a Base64 encoded string, from the cache when it is cached.
    /// </summary>
    /// <param name="base64String">The Base64 encoded image bytes.</param>
    /// <returns>The frozen bitmap image.</returns>
    private BitmapImage GetBitmapImageFromBase64String(string base64String)
    {
        var imageBytes = Convert.FromBase64String(base64String);

        var imageHash = Convert.ToHexString(SHA256.HashData(imageBytes));

        var key = string.Format(CacheKeyFormat, imageHash);

        return _cacheService.GetOrCreate(key, () => CreateBitmapImage(imageBytes));
    }

    /// <summary>
    ///     Decodes image bytes into a frozen bitmap image.
    /// </summary>
    /// <param name="imageBytes">The image bytes.</param>
    /// <returns>The frozen bitmap image.</returns>
    private static BitmapImage CreateBitmapImage(byte[] imageBytes)
    {
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