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
using FrontendMentor.QrCodeComponent.Properties;

namespace FrontendMentor.QrCodeComponent.Services.QrCodes;

/// <inheritdoc />
internal sealed class QrCodesService : IQrCodesService
{
    /// <inheritdoc />
    public Task<QrCodeModel> GetQrCodeAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var qrCode = new QrCodeModel
        {
            Heading = Resources.QrCodeComponentView_HeadingTextBlock_Text,
            Caption = Resources.QrCodeComponentView_CaptionTextBlock_Text
        };

        return Task.FromResult(qrCode);
    }
}