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

using System.Windows;

namespace FrontendMentor.Assets.ResourceDictionaries;

/// <summary>
///     A custom ResourceDictionary for WPF applications that optimizes resource loading and sharing.
///     This class prevents the multiple loading of the same resource dictionaries by maintaining
///     a static cache of loaded dictionaries. When a dictionary is requested, it is either retrieved
///     from the cache (if already loaded) or loaded and then added to the cache for future use.
///     This approach enhances performance and reduces memory usage by reusing dictionaries across
///     the application.
/// </summary>
public class SharedResourceDictionary : ResourceDictionary
{
    private static readonly Dictionary<Uri, ResourceDictionary> SharedDictionaries = [];
    private Uri? _sourceUri;

    /// <summary>
    ///     Overrides the Source property of ResourceDictionary. Setting this property checks if the
    ///     resource dictionary specified by the given URI is already loaded. If so, the loaded dictionary
    ///     is reused by adding it to the MergedDictionaries collection. If not, the dictionary is loaded
    ///     and then added to both the MergedDictionaries collection and the SharedDictionaries cache.
    /// </summary>
    public new Uri? Source
    {
        get => _sourceUri;
        set
        {
            _sourceUri = value;

            if (value == null)
            {
                return;
            }

            if (SharedDictionaries.TryGetValue(value, out var dictionary))
            {
                MergedDictionaries.Add(dictionary);
            }
            else
            {
                base.Source = value;

                SharedDictionaries.Add(value, this);
            }
        }
    }
}