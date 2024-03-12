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

using System.Windows.Markup;

namespace FrontendMentor.Assets.MarkupExtensions;

public abstract class LazyMarkupExtension<T> : MarkupExtension where T : class, new()
{
    private static readonly Lazy<T> LazyInstance = new(() => new T());

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return LazyInstance.Value;
    }
}