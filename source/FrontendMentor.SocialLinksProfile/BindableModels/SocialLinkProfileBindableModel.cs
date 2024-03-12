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

using FrontendMentor.Core.Services.Processes;
using FrontendMentor.SocialLinksProfile.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System.Windows.Input;

namespace FrontendMentor.SocialLinksProfile.BindableModels;

internal class SocialLinkProfileBindableModel(
    IProcessesService processesService,
    SocialLinkProfileModel socialLinkProfile) : BindableBase
{
    private ICommand? _openLinkCommand;

    public string Name => socialLinkProfile.Name;

    public ICommand OpenLinkCommand => _openLinkCommand ??= new DelegateCommand(OpenLink);

    private void OpenLink()
    {
        processesService.StartProcess(socialLinkProfile.Link);
    }

    public static SocialLinkProfileBindableModel Create(IContainerExtension containerExtension,
        SocialLinkProfileModel socialLinkProfile)
    {
        return containerExtension.Resolve<SocialLinkProfileBindableModel>((typeof(SocialLinkProfileModel),
            socialLinkProfile));
    }
}