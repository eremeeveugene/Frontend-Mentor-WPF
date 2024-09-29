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

using FrontendMentor.Core.Interfaces;

namespace FrontendMentor.Core.Attributes;

/// <summary>
///     An attribute used to mark properties that can be reset to a default value.
///     The optional parameter <paramref name="defaultValue" /> represents the value to reset the property to.
///     If no default value is provided, the property will be reset to null or its default state.
///     This attribute is typically used in conjunction with interfaces like <see cref="IResettable" />
///     to implement property resetting mechanisms.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class ResettableAttribute(object? defaultValue = null) : Attribute
{
    /// <summary>
    ///     Gets the default value to which the property should be reset.
    /// </summary>
    public object? DefaultValue { get; } = defaultValue;
}