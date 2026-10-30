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

using Microsoft.Extensions.Caching.Memory;

namespace FrontendMentor.Core.Services.Cache;

/// <inheritdoc />
internal sealed class CacheService : ICacheService
{
    private static readonly TimeSpan DefaultSlidingExpiration = TimeSpan.FromMinutes(30);

    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    /// <inheritdoc />
    public TValue GetOrCreate<TValue>(string key, Func<TValue> factory, TimeSpan? slidingExpiration = null)
        where TValue : notnull
    {
        return _memoryCache.GetOrCreate(key, entry =>
        {
            entry.SlidingExpiration = slidingExpiration ?? DefaultSlidingExpiration;

            return factory();
        })!;
    }
}