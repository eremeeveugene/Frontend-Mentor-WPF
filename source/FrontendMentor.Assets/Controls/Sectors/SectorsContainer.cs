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
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace FrontendMentor.Assets.Controls.Sectors;

internal sealed class SectorsContainer : Control, ISectorsContainer
{
    public static readonly DependencyProperty SectorViewProperty = DependencyProperty.Register(
        nameof(SectorView), typeof(ISectorView), typeof(SectorsContainer), new PropertyMetadata(default(ISectorView?)));

    static SectorsContainer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SectorsContainer),
            new FrameworkPropertyMetadata(typeof(SectorsContainer)));
    }

    public SectorsContainer(IRegionManager regionManager)
    {
        RegionManager.SetRegionManager(this, regionManager);
    }

    public ISectorView? SectorView
    {
        get => (ISectorView?)GetValue(SectorViewProperty);
        set => SetValue(SectorViewProperty, value);
    }
}