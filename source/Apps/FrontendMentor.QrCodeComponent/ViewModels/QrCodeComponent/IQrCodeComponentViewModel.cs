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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.QrCodeComponent.BindableModels.QrCode;

namespace FrontendMentor.QrCodeComponent.ViewModels.QrCodeComponent;

/// <summary>
///     The view model of the QR code component.
/// </summary>
internal interface IQrCodeComponentViewModel : ILoadableViewModel
{
    /// <summary>
    ///     Gets the QR code that the card shows, or <c>null</c> until it is loaded.
    /// </summary>
    IQrCodeBindableModel? QrCode { get; }
}