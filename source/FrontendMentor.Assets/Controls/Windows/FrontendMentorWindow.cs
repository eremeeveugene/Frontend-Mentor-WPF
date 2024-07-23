// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Core.Services.WindowsApi.Dwm;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace FrontendMentor.Assets.Controls.Windows;

public class FrontendMentorWindow : Window
{
    public static readonly DependencyProperty WindowCaptionColorProperty = DependencyProperty.Register(
        nameof(WindowCaptionColor), typeof(Color), typeof(FrontendMentorWindow),
        new PropertyMetadata(default(Color),
            (o, _) => ((FrontendMentorWindow)o).OnWindowCaptionColorPropertyChanged()));

    private readonly IDwmApiService _dwmApiService;
    private readonly IntPtr _windowHandle;

    static FrontendMentorWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FrontendMentorWindow),
            new FrameworkPropertyMetadata(typeof(FrontendMentorWindow)));
    }

    public FrontendMentorWindow(Dependencies dependencies)
    {
        _dwmApiService = dependencies.DwmApiService;
        _windowHandle = new WindowInteropHelper(this).EnsureHandle();
    }

    public Color WindowCaptionColor
    {
        get => (Color)GetValue(WindowCaptionColorProperty);
        set => SetValue(WindowCaptionColorProperty, value);
    }

    private void OnWindowCaptionColorPropertyChanged()
    {
        _dwmApiService.SetWindowCaptionColor(_windowHandle, WindowCaptionColor);
    }

    public class Dependencies(IDwmApiService dwmApiService)
    {
        public IDwmApiService DwmApiService { get; } = dwmApiService;
    }
}