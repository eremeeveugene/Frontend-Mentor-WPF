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
public sealed class DelegateCommandTests
{
    [TestMethod]
    public void Execute_RunsTheDelegate()
    {
        var runCount = 0;
        var command = new DelegateCommand(() => runCount++);

        command.Execute(null);

        Assert.AreEqual(1, runCount);
    }

    [TestMethod]
    public void CanExecute_WithoutPredicate_IsTrue()
    {
        var command = new DelegateCommand(() => { });

        Assert.IsTrue(command.CanExecute(null));
    }

    [TestMethod]
    public void CanExecute_UsesThePredicate()
    {
        var canExecute = false;
        var command = new DelegateCommand(() => { }, () => canExecute);

        Assert.IsFalse(command.CanExecute(null));

        canExecute = true;

        Assert.IsTrue(command.CanExecute(null));
    }

    [TestMethod]
    public void RaiseCanExecuteChanged_RaisesTheEvent()
    {
        var command = new DelegateCommand(() => { });
        var raisedCount = 0;

        command.CanExecuteChanged += (_, _) => raisedCount++;

        command.RaiseCanExecuteChanged();

        Assert.AreEqual(1, raisedCount);
    }
}