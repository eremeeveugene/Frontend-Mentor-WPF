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

using System.Collections.Concurrent;
using System.Windows;

namespace FrontendMentor.Assets.ResourceDictionaries;

/// <summary>
///     A resource dictionary that parses each source only once. The first dictionary that loads a source
///     is cached, and every other dictionary with the same source merges the cached instance instead of
///     parsing the source again. This saves parsing time and memory when the same dictionary is merged
///     from several places.
/// </summary>
public sealed class SharedResourceDictionary : ResourceDictionary
{
    private static readonly ConcurrentDictionary<Uri, ResourceDictionary> SharedDictionaries = [];

    /// <summary>
    ///     Gets or sets the source of the dictionary. Setting a source that is already loaded merges the
    ///     cached dictionary. Setting a source that is not loaded yet loads it into this dictionary and
    ///     caches this dictionary. Setting the source that is already set does nothing.
    /// </summary>
    public new Uri? Source
    {
        get;
        set
        {
            if (value == null || value == field)
            {
                return;
            }

            field = value;

            if (SharedDictionaries.TryGetValue(value, out var sharedDictionary))
            {
                MergedDictionaries.Add(sharedDictionary);

                return;
            }

            base.Source = value;

            SharedDictionaries.TryAdd(value, this);
        }
    }
}