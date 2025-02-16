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

using FrontendMentor.Core.Services.BitmapImages;
using FrontendMentor.ProfileCardComponent.Models;
using System.Windows.Media.Imaging;

namespace FrontendMentor.ProfileCardComponent.BindableModels;

internal class ProfileCardComponentBindableModel(
    IBitmapImagesService bitmapImagesService,
    ProfileCardComponentBindableModel.Parameters parameters) : BindableBase
{
    public string Location { get; } = parameters.Profile.Location;

    public string FirstName { get; } = parameters.Profile.FirstName;

    public string LastName { get; } = parameters.Profile.LastName;

    public int Age { get; } = parameters.Profile.Age;

    public int Followers { get; } = parameters.Profile.Followers;

    public int Likes { get; } = parameters.Profile.Likes;

    public int Photos { get; } = parameters.Profile.Photos;

    public BitmapImage ProfileImage { get; } =
        bitmapImagesService.GetBitmapImageFromBase64String(parameters.Profile.ProfileImageBase64String);

    public static ProfileCardComponentBindableModel Create(IContainerProvider containerProvider, Parameters parameters)
    {
        return containerProvider.Resolve<ProfileCardComponentBindableModel>((typeof(Parameters), parameters));
    }

    public record Parameters(ProfileModel Profile);
}