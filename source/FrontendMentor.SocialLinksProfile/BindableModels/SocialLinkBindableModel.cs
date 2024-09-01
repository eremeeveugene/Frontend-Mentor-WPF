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
using System.Windows.Input;

namespace FrontendMentor.SocialLinksProfile.BindableModels;

internal class SocialLinkBindableModel(
    IProcessesService processesService,
    SocialLinkBindableModel.Parameters parameters) : BindableBase
{
    private ICommand? _openLinkCommand;

    public string Name { get; } = parameters.SocialLink.Name;

    public ICommand OpenLinkCommand => _openLinkCommand ??= new DelegateCommand(OpenLink);

    private void OpenLink()
    {
        processesService.StartProcess(parameters.SocialLink.Link);
    }

    public static SocialLinkBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<SocialLinkBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(SocialLinkModel SocialLink);
}