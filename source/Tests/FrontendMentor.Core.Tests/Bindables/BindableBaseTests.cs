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

using FrontendMentor.Core.Bindables;

namespace FrontendMentor.Core.Tests.Bindables;

[TestClass]
public sealed class BindableBaseTests
{
    [TestMethod]
    public void SetProperty_NewValue_RaisesPropertyChangedOnce()
    {
        var bindable = new TestBindable();
        var raised = new List<string?>();

        bindable.PropertyChanged += (_, args) => raised.Add(args.PropertyName);

        bindable.Name = "first";

        CollectionAssert.AreEqual(new[] { nameof(TestBindable.Name) }, raised);
        Assert.AreEqual("first", bindable.Name);
    }

    [TestMethod]
    public void SetProperty_SameValue_DoesNotRaisePropertyChanged()
    {
        var bindable = new TestBindable { Name = "first" };
        var raisedCount = 0;

        bindable.PropertyChanged += (_, _) => raisedCount++;

        bindable.Name = "first";

        Assert.AreEqual(0, raisedCount);
    }

    private sealed class TestBindable : BindableBase
    {
        public string? Name
        {
            get;
            set => SetProperty(ref field, value);
        }
    }
}