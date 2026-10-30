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

namespace FrontendMentor.Core.Tests.Services;

[TestClass]
public sealed class BitmapImagesServiceTests
{
    private const string OnePixelPngBase64String =
        "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg==";

    [TestMethod]
    public async Task GetBitmapImageFromBase64StringAsync_ReturnsAFrozenImage()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = new BitmapImagesService(new CacheService(memoryCache));

        var image = await service.GetBitmapImageFromBase64StringAsync(OnePixelPngBase64String);

        Assert.IsTrue(image.IsFrozen);
        Assert.AreEqual(1, image.PixelWidth);
        Assert.AreEqual(1, image.PixelHeight);
    }

    [TestMethod]
    public async Task GetBitmapImageFromBase64StringAsync_SameImage_IsDecodedOnce()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = new BitmapImagesService(new CacheService(memoryCache));

        var first = await service.GetBitmapImageFromBase64StringAsync(OnePixelPngBase64String);
        var second = await service.GetBitmapImageFromBase64StringAsync(OnePixelPngBase64String);

        Assert.AreSame(first, second);
    }

    [TestMethod]
    public async Task GetBitmapImageFromBase64StringAsync_InvalidBase64_Throws()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = new BitmapImagesService(new CacheService(memoryCache));

        await Assert.ThrowsExactlyAsync<FormatException>(() =>
            service.GetBitmapImageFromBase64StringAsync("not base64!"));
    }
}