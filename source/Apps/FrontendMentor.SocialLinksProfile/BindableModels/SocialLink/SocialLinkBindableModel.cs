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

using FrontendMentor.Core.Bindables;
using FrontendMentor.Core.Commands;
using FrontendMentor.Core.Services.Processes;
using System.Windows.Input;

namespace FrontendMentor.SocialLinksProfile.BindableModels.SocialLink;

/// <inheritdoc cref="ISocialLinkBindableModel" />
internal sealed class SocialLinkBindableModel : BindableBase, ISocialLinkBindableModel
{
    private readonly string _link;
    private readonly IProcessesService _processesService;

    public SocialLinkBindableModel(IProcessesService processesService, SocialLinkBindableModelParameters parameters)
    {
        var socialLink = parameters.SocialLink;

        _processesService = processesService;
        _link = socialLink.Link;

        Name = socialLink.Name;
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public ICommand OpenLinkCommand => field ??= new DelegateCommand(OpenLink);

    /// <summary>
    ///     Opens the link with the shell.
    /// </summary>
    private void OpenLink()
    {
        _processesService.StartProcess(_link);
    }
}