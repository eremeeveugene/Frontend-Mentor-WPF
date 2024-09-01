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

using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.SocialLinksProfile.Models;
using System.Windows.Media.Imaging;

namespace FrontendMentor.SocialLinksProfile.BindableModels;

internal class SocialLinkProfileBindableModel(
    IContainerProvider containerProvider,
    IBitmapImagesService bitmapImagesService,
    SocialLinkProfileBindableModel.Parameters parameters) : BindableBase
{
    public string FirstName { get; } = parameters.SocialLinkProfile.FirstName;

    public string LastName { get; } = parameters.SocialLinkProfile.LastName;

    public string Title { get; } = parameters.SocialLinkProfile.Title;

    public string Location { get; } = parameters.SocialLinkProfile.Location;

    public BitmapImage ProfileImage { get; } =
        bitmapImagesService.GetBitmapImageFromBase64String(parameters.SocialLinkProfile.ProfileImageBase64String);

    public List<SocialLinkBindableModel> SocialLinks { get; } =
        GetSocialLinks(containerProvider, parameters.SocialLinkProfile.SocialLinks);

    private static List<SocialLinkBindableModel> GetSocialLinks(IContainerProvider containerProvider,
        IEnumerable<SocialLinkModel> socialLinks)
    {
        return socialLinks.Select(socialLink => SocialLinkBindableModel.Create(containerProvider,
            new SocialLinkBindableModel.Parameters(socialLink))).ToList();
    }

    public static SocialLinkProfileBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<SocialLinkProfileBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(SocialLinkProfileModel SocialLinkProfile);
}