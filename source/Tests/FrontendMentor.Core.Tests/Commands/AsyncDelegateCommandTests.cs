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

using FrontendMentor.Core.Commands;

namespace FrontendMentor.Core.Tests.Commands;

[TestClass]
public sealed class AsyncDelegateCommandTests
{
    [TestMethod]
    public void CanExecute_WhileRunning_IsFalse_AndTrueAgainWhenCompleted()
    {
        var completion = new TaskCompletionSource();
        var command = new AsyncDelegateCommand(() => completion.Task);

        Assert.IsTrue(command.CanExecute(null));

        command.Execute(null);

        Assert.IsFalse(command.CanExecute(null));

        completion.SetResult();

        Assert.IsTrue(command.CanExecute(null));
    }

    [TestMethod]
    public void Execute_WhileRunning_DoesNotStartASecondRun()
    {
        var completion = new TaskCompletionSource();
        var runCount = 0;
        var command = new AsyncDelegateCommand(() =>
        {
            runCount++;

            return completion.Task;
        });

        command.Execute(null);
        command.Execute(null);

        Assert.AreEqual(1, runCount);

        completion.SetResult();
    }

    [TestMethod]
    public void Execute_RaisesCanExecuteChangedWhenItStartsAndWhenItCompletes()
    {
        var completion = new TaskCompletionSource();
        var command = new AsyncDelegateCommand(() => completion.Task);
        var raisedCount = 0;

        command.CanExecuteChanged += (_, _) => raisedCount++;

        command.Execute(null);
        completion.SetResult();

        Assert.AreEqual(2, raisedCount);
    }
}