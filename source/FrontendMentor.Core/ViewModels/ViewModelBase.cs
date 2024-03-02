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

using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace FrontendMentor.Core.ViewModels;

public abstract class ViewModelBase : BindableBase
{
    private bool _isLoadedOnce;
    private ICommand? _loadedCommand;
    private ICommand? _unloadedCommand;

    public ICommand LoadedCommand => _loadedCommand ??= new DelegateCommand(LoadedInternal);
    public ICommand UnloadedCommand => _unloadedCommand ??= new DelegateCommand(UnloadedInternal);

    protected virtual Task UnloadedAsync()
    {
        return Task.CompletedTask;
    }

    private async void UnloadedInternal()
    {
        await UnloadedAsync();
    }

    private async void LoadedInternal()
    {
        if (!_isLoadedOnce)
        {
            try
            {
                await LoadedOnceAsync();
            }
            finally
            {
                _isLoadedOnce = true;
            }
        }

        await LoadedAsync();
    }

    protected virtual Task LoadedAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual Task LoadedOnceAsync()
    {
        return Task.CompletedTask;
    }
}