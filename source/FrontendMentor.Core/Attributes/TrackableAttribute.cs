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

namespace FrontendMentor.Core.Attributes;

/// <summary>
///     An attribute used to indicate that changes to the decorated property should be tracked.
///     When applied to a property, this attribute works in conjunction with change tracking mechanisms
///     or interfaces such as <see cref="IChangeTracking" /> to monitor and respond to modifications
///     made to the property's value.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class TrackableAttribute : Attribute;