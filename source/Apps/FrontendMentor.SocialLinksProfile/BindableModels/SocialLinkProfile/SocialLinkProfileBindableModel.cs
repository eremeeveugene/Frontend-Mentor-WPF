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
using FrontendMentor.Core.Extensions;
using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.SocialLinksProfile.BindableModels.SocialLink;
using Microsoft.Extensions.Logging;
using System.Windows.Media.Imaging;

namespace FrontendMentor.SocialLinksProfile.BindableModels.SocialLinkProfile;

/// <inheritdoc cref="ISocialLinkProfileBindableModel" />
internal sealed class SocialLinkProfileBindableModel : BindableBase, ISocialLinkProfileBindableModel
{
    private readonly IBitmapImagesService _bitmapImagesService;
    private readonly ILogger<SocialLinkProfileBindableModel> _logger;

    public SocialLinkProfileBindableModel(
        IBitmapImagesService bitmapImagesService,
        Func<SocialLinkBindableModelParameters, ISocialLinkBindableModel> socialLinkFactory,
        ILogger<SocialLinkProfileBindableModel> logger,
        SocialLinkProfileBindableModelParameters parameters)
    {
        _bitmapImagesService = bitmapImagesService;
        _logger = logger;

        var socialLinkProfile = parameters.SocialLinkProfile;

        FirstName = socialLinkProfile.FirstName;
        LastName = socialLinkProfile.LastName;
        Title = socialLinkProfile.Title;
        Location = socialLinkProfile.Location;

        var socialLinks = new List<ISocialLinkBindableModel>(socialLinkProfile.SocialLinks.Count);

        foreach (var socialLink in socialLinkProfile.SocialLinks)
        {
            socialLinks.Add(socialLinkFactory(new SocialLinkBindableModelParameters(socialLink)));
        }

        SocialLinks = socialLinks;

        LoadProfileImageAsync(socialLinkProfile.ProfileImageBase64String).Observe(_logger, "Failed to load the photo of the profile.");
    }

    /// <inheritdoc />
    public string FirstName { get; }

    /// <inheritdoc />
    public string LastName { get; }

    /// <inheritdoc />
    public string Title { get; }

    /// <inheritdoc />
    public string Location { get; }

    /// <inheritdoc />
    public BitmapImage? ProfileImage
    {
        get;
        private set => SetProperty(ref field, value);
    }

    /// <inheritdoc />
    public IReadOnlyList<ISocialLinkBindableModel> SocialLinks { get; }

    /// <summary>
    ///     Decodes the photo of the person on a background thread and sets it.
    /// </summary>
    /// <param name="imageBase64String">The Base64 encoded photo.</param>
    /// <returns>A task that completes when the photo is set.</returns>
    private async Task LoadProfileImageAsync(string imageBase64String)
    {
        ProfileImage = await _bitmapImagesService.GetBitmapImageFromBase64StringAsync(imageBase64String);
    }
}