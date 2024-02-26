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

public class SharedResourceDictionary : ResourceDictionary
{
    private static readonly Dictionary<Uri, ResourceDictionary> SharedDictionaries = new();
    private Uri? _sourceUri;

    public new Uri? Source
    {
        get => _sourceUri;
        set
        {
            _sourceUri = value;

            if (value == null) return;

            if (!SharedDictionaries.ContainsKey(value))
            {
                base.Source = value;

                SharedDictionaries.Add(value, this);
            }
            else
            {
                MergedDictionaries.Add(SharedDictionaries[value]);
            }
        }
    }
}