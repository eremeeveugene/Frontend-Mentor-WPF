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

using System.Windows.Input;

namespace FrontendMentor.Core.Commands;

/// <summary>
///     A command that runs an asynchronous delegate. The command cannot run again until the previous
///     run is completed. A failure of the delegate is not swallowed: it is raised on the UI thread.
/// </summary>
public sealed class AsyncDelegateCommand : ICommand
{
    private readonly Func<Task> _execute;
    private bool _isRunning;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AsyncDelegateCommand" /> class.
    /// </summary>
    /// <param name="execute">The asynchronous delegate that runs the command.</param>
    public AsyncDelegateCommand(Func<Task> execute)
    {
        _execute = execute;
    }

    /// <inheritdoc />
    public event EventHandler? CanExecuteChanged;

    /// <inheritdoc />
    public bool CanExecute(object? parameter)
    {
        return !_isRunning;
    }

    /// <inheritdoc />
    public async void Execute(object? parameter)
    {
        // The signature is fixed by ICommand. The exception of the delegate is not caught here on
        // purpose, so that it is raised on the UI thread and not lost.
        if (_isRunning)
        {
            return;
        }

        SetIsRunning(true);

        try
        {
            await _execute();
        }
        finally
        {
            SetIsRunning(false);
        }
    }

    /// <summary>
    ///     Sets whether the command is running and raises <see cref="CanExecuteChanged" />.
    /// </summary>
    /// <param name="isRunning">Whether the command is running.</param>
    private void SetIsRunning(bool isRunning)
    {
        _isRunning = isRunning;

        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}