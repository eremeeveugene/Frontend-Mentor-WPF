// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

namespace FrontendMentor.Core.Cache;

/// <summary>
///     Represents a generic resource cache that efficiently manages the loading and storing of resources
///     of type <typeparamref name="T" />. The cache facilitates minimizing redundant resource loading
///     operations by maintaining a dictionary of resources identified by their URIs. When a resource is requested,
///     the class checks if it is already present in the cache. If so, the cached resource is returned, thereby
///     avoiding the overhead of reloading it. If the resource is not in the cache, it is loaded using a provided
///     loader function, added to the cache, and then returned. This mechanism is especially beneficial in
///     scenarios where resources, such as images, cursors, or data files, need to be frequently accessed,
///     as it significantly enhances performance and reduces memory footprint by ensuring that each unique resource
///     is loaded and stored only once.
/// </summary>
/// <typeparam name="T">The type of the resources to be cached, such as BitmapImage, Cursor, or any other object.</typeparam>
public static class ResourceCache<T>
{
    private static readonly Dictionary<Uri, T> Cache = [];

    /// <summary>
    ///     Tries to get a cached resource. If not found, the resource is loaded using the provided loader function,
    ///     added to the cache, and then returned. This method ensures efficient resource management by reusing
    ///     instances of resources wherever possible, reducing the load on the application and improving responsiveness.
    /// </summary>
    /// <param name="uri">The URI of the resource.</param>
    /// <param name="loader">
    ///     A function to load the resource if it's not already in the cache. This function must
    ///     take a URI and return an instance of <typeparamref name="T" />, representing the loaded resource.
    /// </param>
    /// <returns>The cached or newly loaded resource.</returns>
    public static T GetOrAdd(Uri uri, Func<Uri, T> loader)
    {
        if (Cache.TryGetValue(uri, out var resource))
        {
            return resource;
        }

        resource = loader(uri);

        Cache[uri] = resource;

        return resource;
    }
}