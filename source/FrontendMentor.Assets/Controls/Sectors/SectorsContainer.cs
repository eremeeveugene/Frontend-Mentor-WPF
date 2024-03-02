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

using FrontendMentor.Core.Services.Sectors;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace FrontendMentor.Assets.Controls.Sectors;

internal sealed class SectorsContainer : ContentControl, ISectorsContainer
{
    public static readonly DependencyProperty SectorNameProperty = DependencyProperty.Register(
        nameof(SectorName), typeof(string), typeof(SectorsContainer),
        new PropertyMetadata(default(string), SectorPropertyChangedCallback));

    private readonly IContainerExtension _containerExtension;

    static SectorsContainer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SectorsContainer),
            new FrameworkPropertyMetadata(typeof(SectorsContainer)));
    }

    public SectorsContainer(IContainerExtension containerExtension, IRegionManager regionManager)
    {
        _containerExtension = containerExtension;

        RegionManager.SetRegionManager(this, regionManager);
    }

    public string? SectorName
    {
        get => (string)GetValue(SectorNameProperty);
        set => SetValue(SectorNameProperty, value);
    }

    private static void SectorPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is SectorsContainer windowRegionControl)
        {
            windowRegionControl.OnSectorChanged();
        }
    }

    private void OnSectorChanged()
    {
        Content = SectorName == null ? null : _containerExtension.Resolve<ISectorView>(SectorName);
    }
}