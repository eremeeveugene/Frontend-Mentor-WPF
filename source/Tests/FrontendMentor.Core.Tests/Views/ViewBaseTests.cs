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

using FrontendMentor.Core.ViewModels;
using FrontendMentor.Core.Views;
using System.ComponentModel;

namespace FrontendMentor.Core.Tests.Views;

[TestClass]
public sealed class ViewBaseTests
{
    [STATestMethod]
    public void Constructor_BindsToTheViewModel()
    {
        var viewModel = new PlainViewModel();

        var view = new TestView(viewModel);

        Assert.AreSame(viewModel, view.DataContext);
    }

    private sealed class TestView(IViewModel viewModel) : ViewBase(viewModel);

    private sealed class PlainViewModel : IViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged
        {
            add { }
            remove { }
        }
    }
}