// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Assets.Controls.Windows;
using FrontendMentor.QrCodeComponent.Views.QrCodeComponent;
using System.Windows;

namespace FrontendMentor.QrCodeComponent.Controls;

/// <inheritdoc cref="IQrCodeComponentWindow" />
internal sealed class QrCodeComponentWindow : FrontendMentorWindow, IQrCodeComponentWindow
{
    static QrCodeComponentWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(QrCodeComponentWindow),
            new FrameworkPropertyMetadata(typeof(QrCodeComponentWindow)));
    }

    public QrCodeComponentWindow(IQrCodeComponentView view)
        : base(view)
    {
    }
}