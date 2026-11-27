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
using System.Net.Http;
using System.Security.Cryptography;
using System.Windows.Media.Imaging;

namespace FrontendMentor.Core.Services.BitmapImages;

/// <inheritdoc />
internal sealed class BitmapImagesService : IBitmapImagesService
{
    /// <summary>
    ///     The name of the HTTP client that downloads images.
    /// </summary>
    internal const string HttpClientName = nameof(BitmapImagesService);

    private const string CacheKeyFormat = $"{nameof(BitmapImagesService)}:{{0}}";
    private const string UrlCacheKeyFormat = $"{nameof(BitmapImagesService)}:{{0}}:{{1}}";

    private readonly ICacheService _cacheService;
    private readonly IHttpClientFactory _httpClientFactory;

    public BitmapImagesService(ICacheService cacheService, IHttpClientFactory httpClientFactory)
    {
        _cacheService = cacheService;
        _httpClientFactory = httpClientFactory;
    }

    /// <inheritdoc />
    public Task<BitmapImage> GetBitmapImageFromBase64StringAsync(string base64String, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => GetBitmapImageFromBase64String(base64String), cancellationToken);
    }

    /// <inheritdoc />
    public Task<BitmapImage> GetBitmapImageFromUrlAsync(Uri url, int decodePixelWidth,
        CancellationToken cancellationToken = default)
    {
        var key = string.Format(UrlCacheKeyFormat, decodePixelWidth, url.AbsoluteUri);

        return _cacheService.TryGet<BitmapImage>(key, out var cachedImage)
            ? Task.FromResult(cachedImage)
            : Task.Run(() => DownloadBitmapImageAsync(key, url, decodePixelWidth, cancellationToken), cancellationToken);
    }

    /// <summary>
    ///     Downloads an image, decodes it and caches it.
    /// </summary>
    /// <param name="key">The cache key of the image.</param>
    /// <param name="url">The URL of the image.</param>
    /// <param name="decodePixelWidth">The width in pixels that the image is decoded to.</param>
    /// <param name="cancellationToken">The token that cancels the operation.</param>
    /// <returns>The frozen bitmap image.</returns>
    private async Task<BitmapImage> DownloadBitmapImageAsync(
        string key,
        Uri url,
        int decodePixelWidth,
        CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient(HttpClientName);

        var imageBytes = await httpClient.GetByteArrayAsync(url, cancellationToken);

        return _cacheService.GetOrCreate(key, () => CreateBitmapImage(imageBytes, decodePixelWidth));
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

        return _cacheService.GetOrCreate(key, () => CreateBitmapImage(imageBytes, 0));
    }

    /// <summary>
    ///     Decodes image bytes into a frozen bitmap image.
    /// </summary>
    /// <param name="imageBytes">The image bytes.</param>
    /// <param name="decodePixelWidth">The width in pixels that the image is decoded to, or 0 for its own width.</param>
    /// <returns>The frozen bitmap image.</returns>
    private static BitmapImage CreateBitmapImage(byte[] imageBytes, int decodePixelWidth)
    {
        using var memoryStream = new MemoryStream(imageBytes);

        var bitmapImage = new BitmapImage();

        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.DecodePixelWidth = decodePixelWidth;
        bitmapImage.StreamSource = memoryStream;
        bitmapImage.EndInit();
        bitmapImage.Freeze();

        return bitmapImage;
    }
}