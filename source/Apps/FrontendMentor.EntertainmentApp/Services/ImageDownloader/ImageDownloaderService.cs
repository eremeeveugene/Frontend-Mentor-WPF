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

using System.Net.Http;

namespace FrontendMentor.EntertainmentApp.Services.ImageDownloader;

internal sealed class ImageDownloaderService : IImageDownloaderService
{
    private readonly HttpClient _httpClient;

    public ImageDownloaderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<byte[]> DownloadAsync(string url, CancellationToken cancellationToken = default)
    {
        return _httpClient.GetByteArrayAsync(url, cancellationToken);
    }
}