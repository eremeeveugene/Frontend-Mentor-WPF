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

using FrontendMentor.Core.DataErrors;
using System.Collections;

namespace FrontendMentor.Core.Tests.DataErrors;

[TestClass]
public sealed class DataErrorsContainerTests
{
    private readonly object _owner = new();
    private DataErrorsContainer _errors = null!;
    private List<(object? Sender, string? PropertyName)> _changes = null!;

    [TestInitialize]
    public void Initialize()
    {
        _errors = new DataErrorsContainer(_owner);
        _changes = [];
        _errors.ErrorsChanged += (sender, e) => _changes.Add((sender, e.PropertyName));
    }

    [TestMethod]
    public void SetError_StoresTheErrorAndReportsTheChangeFromTheOwner()
    {
        _errors.SetError("Amount", "Required");

        Assert.IsTrue(_errors.HasErrors);
        CollectionAssert.AreEqual(new[] { "Required" }, ToArray(_errors.GetErrors("Amount")));
        Assert.HasCount(1, _changes);
        Assert.AreSame(_owner, _changes[0].Sender);
        Assert.AreEqual("Amount", _changes[0].PropertyName);
    }

    [TestMethod]
    public void SetError_SameErrorAgain_DoesNotReportAChange()
    {
        _errors.SetError("Amount", "Required");
        _errors.SetError("Amount", "Required");

        Assert.HasCount(1, _changes);
    }

    [TestMethod]
    public void SetError_Null_ClearsTheError()
    {
        _errors.SetError("Amount", "Required");
        _errors.SetError("Amount", null);

        Assert.IsFalse(_errors.HasErrors);
        Assert.IsEmpty(ToArray(_errors.GetErrors("Amount")));
        Assert.HasCount(2, _changes);
    }

    [TestMethod]
    public void ClearError_PropertyWithoutError_DoesNotReportAChange()
    {
        _errors.ClearError("Amount");

        Assert.IsEmpty(_changes);
    }

    [TestMethod]
    public void GetErrors_NoPropertyName_ReturnsAllErrors()
    {
        _errors.SetError("Amount", "Required");
        _errors.SetError("Term", "Too short");

        CollectionAssert.AreEquivalent(new[] { "Required", "Too short" }, ToArray(_errors.GetErrors(null)));
    }

    [TestMethod]
    public void ClearErrors_ClearsAllAndReportsEachProperty()
    {
        _errors.SetError("Amount", "Required");
        _errors.SetError("Term", "Too short");
        _changes.Clear();

        _errors.ClearErrors();

        Assert.IsFalse(_errors.HasErrors);
        CollectionAssert.AreEquivalent(new[] { "Amount", "Term" }, GetChangedPropertyNames());
    }

    private static string[] ToArray(IEnumerable errors)
    {
        var list = new List<string>();

        foreach (var error in errors)
        {
            list.Add((string)error);
        }

        return list.ToArray();
    }

    private string?[] GetChangedPropertyNames()
    {
        var propertyNames = new List<string?>();

        foreach (var (_, propertyName) in _changes)
        {
            propertyNames.Add(propertyName);
        }

        return propertyNames.ToArray();
    }
}