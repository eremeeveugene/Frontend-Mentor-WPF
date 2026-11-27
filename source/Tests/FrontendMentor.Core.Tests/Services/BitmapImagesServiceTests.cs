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
using FrontendMentor.Core.Services.Cache;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Net.Http;

namespace FrontendMentor.Core.Tests.Services;

[TestClass]
public sealed class BitmapImagesServiceTests
{
    private const string OnePixelPngBase64String =
        "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg==";

    private static readonly Uri ImageUrl = new("https://example.com/image.png");

    [TestMethod]
    public async Task GetBitmapImageFromBase64StringAsync_ReturnsAFrozenImage()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = CreateService(memoryCache);

        var image = await service.GetBitmapImageFromBase64StringAsync(OnePixelPngBase64String);

        Assert.IsTrue(image.IsFrozen);
        Assert.AreEqual(1, image.PixelWidth);
        Assert.AreEqual(1, image.PixelHeight);
    }

    [TestMethod]
    public async Task GetBitmapImageFromBase64StringAsync_SameImage_IsDecodedOnce()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = CreateService(memoryCache);

        var first = await service.GetBitmapImageFromBase64StringAsync(OnePixelPngBase64String);
        var second = await service.GetBitmapImageFromBase64StringAsync(OnePixelPngBase64String);

        Assert.AreSame(first, second);
    }

    [TestMethod]
    public async Task GetBitmapImageFromBase64StringAsync_InvalidBase64_Throws()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = CreateService(memoryCache);

        await Assert.ThrowsExactlyAsync<FormatException>(() =>
            service.GetBitmapImageFromBase64StringAsync("not base64!"));
    }

    [TestMethod]
    public async Task GetBitmapImageFromUrlAsync_DecodesToTheRequestedWidth()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = CreateService(memoryCache);

        var image = await service.GetBitmapImageFromUrlAsync(ImageUrl, 4);

        Assert.IsTrue(image.IsFrozen);
        Assert.AreEqual(4, image.PixelWidth);
    }

    [TestMethod]
    public async Task GetBitmapImageFromUrlAsync_SameUrlAndWidth_IsDownloadedOnce()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        using var handler = new FakeImageHandler(HttpStatusCode.OK);
        var service = CreateService(memoryCache, handler);

        var first = await service.GetBitmapImageFromUrlAsync(ImageUrl, 4);
        var second = await service.GetBitmapImageFromUrlAsync(ImageUrl, 4);

        Assert.AreSame(first, second);
        Assert.AreEqual(1, handler.RequestCount);
    }

    [TestMethod]
    public async Task GetBitmapImageFromUrlAsync_OtherWidth_IsAnotherImage()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = CreateService(memoryCache);

        var small = await service.GetBitmapImageFromUrlAsync(ImageUrl, 2);
        var large = await service.GetBitmapImageFromUrlAsync(ImageUrl, 4);

        Assert.AreEqual(2, small.PixelWidth);
        Assert.AreEqual(4, large.PixelWidth);
    }

    [TestMethod]
    public async Task GetBitmapImageFromUrlAsync_FailedDownload_ThrowsAndIsNotCached()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        using var handler = new FakeImageHandler(HttpStatusCode.NotFound);
        var service = CreateService(memoryCache, handler);

        await Assert.ThrowsExactlyAsync<HttpRequestException>(() => service.GetBitmapImageFromUrlAsync(ImageUrl, 4));
        await Assert.ThrowsExactlyAsync<HttpRequestException>(() => service.GetBitmapImageFromUrlAsync(ImageUrl, 4));

        Assert.AreEqual(2, handler.RequestCount);
    }

    private static BitmapImagesService CreateService(IMemoryCache memoryCache, FakeImageHandler? handler = null)
    {
        return new BitmapImagesService(
            new CacheService(memoryCache),
            new FakeHttpClientFactory(handler ?? new FakeImageHandler(HttpStatusCode.OK)));
    }

    private sealed class FakeHttpClientFactory : IHttpClientFactory
    {
        private readonly HttpMessageHandler _handler;

        public FakeHttpClientFactory(HttpMessageHandler handler)
        {
            _handler = handler;
        }

        public HttpClient CreateClient(string name)
        {
            return new HttpClient(_handler, false);
        }
    }

    private sealed class FakeImageHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode _statusCode;

        public FakeImageHandler(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

        public int RequestCount { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestCount++;

            var response = new HttpResponseMessage(_statusCode)
            {
                Content = new ByteArrayContent(Convert.FromBase64String(OnePixelPngBase64String))
            };

            return Task.FromResult(response);
        }
    }
}