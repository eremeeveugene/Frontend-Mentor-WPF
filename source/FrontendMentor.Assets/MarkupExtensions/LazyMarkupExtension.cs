// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using System.Windows.Markup;

namespace FrontendMentor.Assets.MarkupExtensions;

/// <summary>
///     The base class for markup extensions that provide one lazily created shared instance.
/// </summary>
public abstract class LazyMarkupExtension<T> : MarkupExtension where T : class, new()
{
    private static readonly Lazy<T> LazyInstance = new(() => new T());

    /// <inheritdoc />
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return LazyInstance.Value;
    }
}