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

using FrontendMentor.QrCodeComponent.BindableModels.QrCode;
using FrontendMentor.QrCodeComponent.Models.QrCodes;

namespace FrontendMentor.QrCodeComponent.Factories.QrCode;

/// <summary>
///     Creates the presentation models of QR code cards.
/// </summary>
internal interface IQrCodeBindableModelFactory
{
    /// <summary>
    ///     Creates the presentation model of a QR code card.
    /// </summary>
    /// <param name="qrCode">The data of a QR code card.</param>
    /// <returns>The presentation model.</returns>
    IQrCodeBindableModel Create(QrCodeModel qrCode);
}