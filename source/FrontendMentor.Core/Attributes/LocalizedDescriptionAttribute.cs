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

public class LocalizedDescriptionAttribute(string resourceKey, Type resourceType) : DescriptionAttribute
{
    private readonly ResourceManager _resourceManager = new(resourceType);

    public override string? Description
    {
        get
        {
            var description = _resourceManager.GetString(resourceKey);

            return string.IsNullOrWhiteSpace(description) ? $"[[{resourceKey}]]" : description;
        }
    }
}