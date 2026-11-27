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

using System.Windows.Media.Imaging;

namespace FrontendMentor.Core.Services.BitmapImages;

/// <summary>
///     Creates frozen bitmap images.
/// </summary>
public interface IBitmapImagesService
{
    /// <summary>
    ///     Gets a frozen bitmap image from a Base64 encoded string. The decoding runs on a background thread.
    /// </summary>
    /// <param name="base64String">The Base64 encoded image bytes.</param>
    /// <param name="cancellationToken">The token that cancels the operation.</param>
    /// <returns>The frozen bitmap image.</returns>
    Task<BitmapImage> GetBitmapImageFromBase64StringAsync(string base64String,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets a frozen bitmap image from a URL, from the cache when it is cached. The download and the decoding
    ///     run on background threads.
    /// </summary>
    /// <param name="url">The absolute URL of the image.</param>
    /// <param name="decodePixelWidth">The width in pixels that the image is decoded to.</param>
    /// <param name="cancellationToken">The token that cancels the operation.</param>
    /// <returns>The frozen bitmap image.</returns>
    Task<BitmapImage> GetBitmapImageFromUrlAsync(Uri url, int decodePixelWidth,
        CancellationToken cancellationToken = default);
}