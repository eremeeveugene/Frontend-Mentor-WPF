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

using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;

namespace FrontendMentor.Core.ViewModels;

public abstract class ViewModelBase : BindableBase, IRegionMemberLifetime, IDestructible
{
    public virtual void Destroy()
    {
    }

    public bool KeepAlive => false;
}