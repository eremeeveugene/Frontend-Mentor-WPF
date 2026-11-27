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

using FrontendMentor.Assets.Converters;
using FrontendMentor.Assets.Enums;
using System.Globalization;
using System.Windows.Data;

namespace FrontendMentor.Assets.Tests.Converters;

[TestClass]
public sealed class EqualityParameterToBooleanConverterTests
{
    private readonly EqualityParameterToBooleanConverter _converter = new();

    [TestMethod]
    public void Convert_ValueEqualsParameter_IsTrue()
    {
        Assert.AreEqual(true, _converter.Convert(Theme.Dark, typeof(bool), Theme.Dark, CultureInfo.InvariantCulture));
    }

    [TestMethod]
    public void Convert_OtherOrMissingValue_IsFalse()
    {
        Assert.AreEqual(false, _converter.Convert(Theme.Light, typeof(bool), Theme.Dark, CultureInfo.InvariantCulture));
        Assert.AreEqual(false, _converter.Convert(null, typeof(bool), Theme.Dark, CultureInfo.InvariantCulture));
    }

    [TestMethod]
    public void ConvertBack_True_IsTheParameter()
    {
        Assert.AreEqual(Theme.Dark, _converter.ConvertBack(true, typeof(Theme), Theme.Dark, CultureInfo.InvariantCulture));
    }

    [TestMethod]
    public void ConvertBack_False_DoesNothing()
    {
        Assert.AreSame(Binding.DoNothing, _converter.ConvertBack(false, typeof(Theme), Theme.Dark, CultureInfo.InvariantCulture));
    }
}