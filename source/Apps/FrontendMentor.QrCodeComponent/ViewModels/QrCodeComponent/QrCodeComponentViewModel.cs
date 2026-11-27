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

using FrontendMentor.Core.Bindables;
using FrontendMentor.QrCodeComponent.BindableModels.QrCode;
using FrontendMentor.QrCodeComponent.Factories.QrCode;
using FrontendMentor.QrCodeComponent.Services.QrCodes;

namespace FrontendMentor.QrCodeComponent.ViewModels.QrCodeComponent;

/// <inheritdoc cref="IQrCodeComponentViewModel" />
internal sealed class QrCodeComponentViewModel : BindableBase, IQrCodeComponentViewModel
{
    private readonly IQrCodeBindableModelFactory _qrCodeFactory;
    private readonly IQrCodesService _qrCodesService;

    public QrCodeComponentViewModel(IQrCodeBindableModelFactory qrCodeFactory, IQrCodesService qrCodesService)
    {
        _qrCodeFactory = qrCodeFactory;
        _qrCodesService = qrCodesService;
    }

    /// <inheritdoc />
    public IQrCodeBindableModel? QrCode
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public async Task LoadAsync(CancellationToken cancellationToken)
    {
        var qrCode = await _qrCodesService.GetQrCodeAsync(cancellationToken);

        QrCode = _qrCodeFactory.Create(qrCode);
    }
}