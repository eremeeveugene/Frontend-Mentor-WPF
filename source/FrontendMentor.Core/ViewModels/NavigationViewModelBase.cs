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

using Prism.Regions;

namespace FrontendMentor.Core.ViewModels;

public abstract class NavigationViewModelBase : ViewModelBase, INavigationAware
{
    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
    }

    public virtual bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return false;
    }

    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }
}