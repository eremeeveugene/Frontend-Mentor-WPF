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
using Microsoft.Extensions.Caching.Memory;

namespace FrontendMentor.Core.Tests.Services;

[TestClass]
public sealed class CacheServiceTests
{
    [TestMethod]
    public void GetOrCreate_CreatesTheValueOnlyOncePerKey()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var cacheService = new CacheService(memoryCache);
        var createdCount = 0;

        var first = cacheService.GetOrCreate("key", () => $"value {++createdCount}");
        var second = cacheService.GetOrCreate("key", () => $"value {++createdCount}");

        Assert.AreEqual(1, createdCount);
        Assert.AreEqual(first, second);
    }

    [TestMethod]
    public void GetOrCreate_DifferentKeysCreateDifferentValues()
    {
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var cacheService = new CacheService(memoryCache);

        var first = cacheService.GetOrCreate("first", () => "a");
        var second = cacheService.GetOrCreate("second", () => "b");

        Assert.AreEqual("a", first);
        Assert.AreEqual("b", second);
    }
}