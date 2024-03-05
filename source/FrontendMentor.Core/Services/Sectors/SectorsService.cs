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

namespace FrontendMentor.Core.Services.Sectors;

internal class SectorsService(ISectorsContainer sectorContainer) : ISectorsService
{
    private readonly Dictionary<string, Type> _sectors = [];

    public void NavigateToSectorView(string sectorRegion)
    {
        sectorContainer.SectorView = GetSectorView(sectorRegion);
    }

    public void RegisterSectorView<T>(string sectorName) where T : ISectorView
    {
        _sectors[sectorName] = typeof(T);
    }

    public ISectorView GetSectorView(string sectorName)
    {
        if (_sectors.TryGetValue(sectorName, out var sectorType))
        {
            return Activator.CreateInstance(sectorType) as ISectorView ?? throw new InvalidOperationException();
        }

        throw new InvalidOperationException($"No sector registered with name: {sectorName}");
    }
}