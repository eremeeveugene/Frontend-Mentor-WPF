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

using FrontendMentor.Core.BindableModels;
using System.Windows.Input;

namespace FrontendMentor.SocialLinksProfile.BindableModels.SocialLink;

/// <summary>
///     The presentation model of a social link.
/// </summary>
internal interface ISocialLinkBindableModel : IBindableModel
{
    /// <summary>
    ///     Gets the name of the social network.
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     Gets the command that opens the link.
    /// </summary>
    ICommand OpenLinkCommand { get; }
}