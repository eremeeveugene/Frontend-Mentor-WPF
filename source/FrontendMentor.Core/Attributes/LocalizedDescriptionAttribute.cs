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

    /// <summary>
    ///     Initializes a new instance of the <see cref="LocalizedDescriptionAttribute" /> class.
    /// </summary>
    /// <param name="resourceKey">The key of the description in the resources.</param>
    /// <param name="resourceType">The type that gives access to the resources.</param>
    /// <param name="fallbackDescription">The description that is used when the resources have no such key.</param>
    public LocalizedDescriptionAttribute(string resourceKey, Type resourceType, string fallbackDescription)
        : base(fallbackDescription)
    {
        _resourceKey = resourceKey;
        _resourceManager = new ResourceManager(resourceType);
    }

    /// <inheritdoc />
    public override string Description => field ??= _resourceManager.GetString(_resourceKey) ?? base.Description;
}