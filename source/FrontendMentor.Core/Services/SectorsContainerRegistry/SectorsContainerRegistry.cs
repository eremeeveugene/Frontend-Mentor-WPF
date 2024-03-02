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

namespace FrontendMentor.Core.Services.SectorsContainerRegistry;

//internal class SectorsContainerRegistry(IContainerRegistry containerRegistry) : ISectorsContainerRegistry
//{
//    public void RegisterSector<T>(string sectorName) where T : ISectorView
//    {
//        containerRegistry.Register<ISectorView, T>(sectorName);
//    }
//}

public static class SectorsContainerRegistry
{
    public static IContainerRegistry RegisterSector<T>(this IContainerRegistry containerRegistry,
        string sectorName) where T : ISectorView
    {
        return containerRegistry.Register<ISectorView, T>(sectorName);
    }
}