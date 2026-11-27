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

/// <inheritdoc />
internal sealed class QrCodeBindableModelFactory : IQrCodeBindableModelFactory
{
    /// <inheritdoc />
    public IQrCodeBindableModel Create(QrCodeModel qrCode)
    {
        return new QrCodeBindableModel(qrCode);
    }
}