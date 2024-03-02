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

using FrontendMentor.Core.Cache;
using FrontendMentor.Core.Properties;
using System.Windows;
using System.Windows.Input;

namespace FrontendMentor.Core.Helpers;

/// <summary>
///     Provides methods for efficiently loading and caching cursors in a WPF application.
///     Utilizes a generic resource cache to store and reuse cursor instances,
///     reducing the overhead of loading cursors from resources multiple times.
/// </summary>
public static class CursorsHelper
{
    /// <summary>
    ///     Loads a cursor from the specified URI. Utilizes a cache to avoid reloading cursors.
    /// </summary>
    /// <param name="uri">The URI of the cursor resource.</param>
    /// <returns>The loaded cursor.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the cursor cannot be loaded.</exception>
    public static Cursor LoadCursor(Uri uri)
    {
        return ResourceCache<Cursor>.GetOrAdd(uri, LoadCursorFromResource);
    }

    /// <summary>
    ///     Loads a cursor from a resource URI.
    /// </summary>
    /// <param name="uri">The resource URI.</param>
    /// <returns>The loaded cursor.</returns>
    private static Cursor LoadCursorFromResource(Uri uri)
    {
        var streamResourceInfo = Application.GetResourceStream(uri);

        return streamResourceInfo == null
            ? throw new InvalidOperationException(string.Format(Resources.CursorLoadErrorMessageStringFormat, uri))
            : new Cursor(streamResourceInfo.Stream);
    }
}