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

using FrontendMentor.QrCodeComponent.Models.QrCodes;

namespace FrontendMentor.QrCodeComponent.Services.QrCodes;

/// <summary>
///     Provides QR code cards.
/// </summary>
internal interface IQrCodesService
{
    /// <summary>
    ///     Gets the QR code that the card shows.
    /// </summary>
    /// <param name="cancellationToken">The token that cancels the request.</param>
    /// <returns>A task that completes with the QR code.</returns>
    /// <remarks>
    ///     The method is asynchronous to simulate retrieving the QR code from a backend service.
    ///     The data is local, so the task completes immediately.
    /// </remarks>
    Task<QrCodeModel> GetQrCodeAsync(CancellationToken cancellationToken = default);
}