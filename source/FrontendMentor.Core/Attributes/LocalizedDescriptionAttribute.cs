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

using System.ComponentModel;
using System.Resources;

namespace FrontendMentor.Core.Attributes;

/// <summary>
///     An attribute to provide localized descriptions for enum values.
/// </summary>
public sealed class LocalizedDescriptionAttribute : DescriptionAttribute
{
    private readonly string _resourceKey;
    private readonly ResourceManager _resourceManager;

    public LocalizedDescriptionAttribute(string resourceKey, Type resourceType, string fallbackDescription)
        : base(fallbackDescription)
    {
        _resourceKey = resourceKey;
        _resourceManager = new ResourceManager(resourceType);
    }

    /// <inheritdoc />
    public override string Description => field ??= _resourceManager.GetString(_resourceKey) ?? base.Description;
}