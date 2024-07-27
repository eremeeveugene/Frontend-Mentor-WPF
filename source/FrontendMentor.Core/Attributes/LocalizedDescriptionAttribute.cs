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

using System.ComponentModel;
using System.Resources;

namespace FrontendMentor.Core.Attributes;

/// <summary>
///     An attribute to provide localized descriptions for enum values.
/// </summary>
public class LocalizedDescriptionAttribute(string resourceKey, Type resourceType, string fallbackDescription)
    : DescriptionAttribute(fallbackDescription)
{
    private static readonly Dictionary<(Type, string), string> DescriptionCache = [];
    private readonly ResourceManager _resourceManager = new(resourceType);

    public override string? Description
    {
        get
        {
            if (DescriptionCache.TryGetValue((_resourceManager.GetType(), resourceKey), out var description))
            {
                return description;
            }

            description = _resourceManager.GetString(resourceKey) ?? base.Description;

            DescriptionCache[(_resourceManager.GetType(), resourceKey)] = description;

            return description;
        }
    }
}