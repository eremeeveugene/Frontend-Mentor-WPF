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

namespace FrontendMentor.QrCodeComponent.Models.QrCodes;

/// <summary>
///     The data of a QR code card.
/// </summary>
internal sealed class QrCodeModel
{
    /// <summary>
    ///     Gets or initializes the heading.
    /// </summary>
    public required string Heading { get; init; }

    /// <summary>
    ///     Gets or initializes the caption.
    /// </summary>
    public required string Caption { get; init; }
}