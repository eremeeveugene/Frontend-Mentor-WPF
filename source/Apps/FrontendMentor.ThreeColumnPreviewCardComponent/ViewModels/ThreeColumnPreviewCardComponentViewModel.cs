// --------------------------------------------------------------------------------
// Copyright (C) 2025 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Core.ViewModels;
using System.Windows.Input;

namespace FrontendMentor.ThreeColumnPreviewCardComponent.ViewModels;

internal class ThreeColumnPreviewCardComponentViewModel : NavigationViewModelBase
{
    private ICommand? _learnMoreAboutLuxuryCommand;
    private ICommand? _learnMoreAboutSedanCommand;
    private ICommand? _learnMoreAboutSuvCommand;

    public ICommand LearnMoreAboutSedanCommand =>
        _learnMoreAboutSedanCommand ??= new DelegateCommand(LearnMoreAboutSedan);

    public ICommand LearnMoreAboutSuvCommand =>
        _learnMoreAboutSuvCommand ??= new DelegateCommand(LearnMoreAboutSuv);

    public ICommand LearnMoreAboutLuxuryCommand =>
        _learnMoreAboutLuxuryCommand ??= new DelegateCommand(LearnMoreAboutLuxury);

    private void LearnMoreAboutSuv()
    {
        // Implement learn more about suv functionality
    }

    private void LearnMoreAboutLuxury()
    {
        // Implement learn more about luxury functionality
    }

    private void LearnMoreAboutSedan()
    {
        // Implement learn more about sedan functionality
    }
}