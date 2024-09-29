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

namespace FrontendMentor.Core.Interfaces;

/// <summary>
///     Defines a contract for objects that can be reset to their initial or default state.
///     Implementing classes must provide a <see cref="Reset" /> method that reverts the object to its default values or
///     configuration.
/// </summary>
public interface IResettable
{
    /// <summary>
    ///     Resets the object to its default or initial state.
    /// </summary>
    void Reset();
}