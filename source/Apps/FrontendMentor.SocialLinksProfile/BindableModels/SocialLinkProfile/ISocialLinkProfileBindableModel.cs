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
using FrontendMentor.SocialLinksProfile.BindableModels.SocialLink;
using System.Windows.Media.Imaging;

namespace FrontendMentor.SocialLinksProfile.BindableModels.SocialLinkProfile;

/// <summary>
///     The presentation model of a social link profile.
/// </summary>
internal interface ISocialLinkProfileBindableModel : IBindableModel
{
    /// <summary>
    ///     Gets the first name of the person.
    /// </summary>
    string FirstName { get; }

    /// <summary>
    ///     Gets the last name of the person.
    /// </summary>
    string LastName { get; }

    /// <summary>
    ///     Gets the title of the person.
    /// </summary>
    string Title { get; }

    /// <summary>
    ///     Gets the location of the person.
    /// </summary>
    string Location { get; }

    /// <summary>
    ///     Gets the photo of the person, or <c>null</c> until it is loaded.
    /// </summary>
    BitmapImage? ProfileImage { get; }

    /// <summary>
    ///     Gets the social links of the person.
    /// </summary>
    IReadOnlyList<ISocialLinkBindableModel> SocialLinks { get; }
}