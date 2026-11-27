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

using System.Diagnostics.CodeAnalysis;

namespace FrontendMentor.Core.Services.Cache;

/// <summary>
///     Caches values by key.
/// </summary>
public interface ICacheService
{
    /// <summary>
    ///     Gets the cached value for a key, or creates the value with a factory and caches it.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="key">The key of the value.</param>
    /// <param name="factory">The factory that creates the value when it is not cached.</param>
    /// <param name="slidingExpiration">
    ///     The time without access after which the value is removed from the cache.
    ///     When <c>null</c>, a default time is used.
    /// </param>
    /// <returns>The cached or the newly created value.</returns>
    TValue GetOrCreate<TValue>(string key, Func<TValue> factory, TimeSpan? slidingExpiration = null)
        where TValue : notnull;

    /// <summary>
    ///     Gets the cached value for a key, if there is one.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="key">The key of the value.</param>
    /// <param name="value">The cached value, or <c>null</c> when nothing is cached for the key.</param>
    /// <returns><c>true</c> when a value is cached.</returns>
    bool TryGet<TValue>(string key, [NotNullWhen(true)] out TValue? value)
        where TValue : notnull;
}