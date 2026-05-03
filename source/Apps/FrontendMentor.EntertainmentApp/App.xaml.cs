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

using FrontendMentor.EntertainmentApp.Interfaces.ViewModels;
using FrontendMentor.EntertainmentApp.Interfaces.Views;
using FrontendMentor.EntertainmentApp.Services.ImageCache;
using FrontendMentor.EntertainmentApp.Services.ImageLoader;
using FrontendMentor.EntertainmentApp.Services.Tmdb;
using FrontendMentor.EntertainmentApp.ViewModels;
using FrontendMentor.EntertainmentApp.ViewModels.TabItems;
using FrontendMentor.EntertainmentApp.Views;
using FrontendMentor.EntertainmentApp.Views.TabItems;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Windows;

namespace FrontendMentor.EntertainmentApp;

internal sealed partial class App
{
    protected override Window GetMainWindow()
    {
        return GetWindow<IEntertainmentAppWindowView, IEntertainmentAppWindowViewModel>();
    }

    protected override void AddServices(IServiceCollection serviceCollection)
    {
        base.AddServices(serviceCollection);

        serviceCollection.AddTransient<IEntertainmentAppWindowView, EntertainmentAppWindowView>();
        serviceCollection.AddTransient<IEntertainmentAppWindowViewModel, EntertainmentAppWindowViewModel>();
        serviceCollection.AddTransient<IBookmarksTabItemView, BookmarksTabItemView>();
        serviceCollection.AddTransient<IBookmarksTabItemViewModel, BookmarksTabItemViewModel>();
        serviceCollection.AddTransient<IHomeTabItemView, HomeTabItemView>();
        serviceCollection.AddTransient<IHomeTabItemViewModel, HomeTabItemViewModel>();
        serviceCollection.AddTransient<IMoviesTabItemView, MoviesTabItemView>();
        serviceCollection.AddTransient<IMoviesTabItemViewModel, MoviesTabItemViewModel>();
        serviceCollection.AddTransient<ISeriesTabItemView, SeriesTabItemView>();
        serviceCollection.AddTransient<ISeriesTabItemViewModel, SeriesTabItemViewModel>();
        serviceCollection.AddSingleton<ITmdbService, TmdbService>();
        serviceCollection.AddSingleton<IImageCacheService, ImageCacheService>();
        serviceCollection.AddSingleton<IImageLoaderService, ImageLoaderService>();

        var configurationBuilder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false).Build();

        serviceCollection.Configure<Configuration>(configurationBuilder);

        var configuration = configurationBuilder.Get<Configuration>()!;

        serviceCollection.AddSingleton(configuration);

        serviceCollection.AddHttpClient(
            "tmdb",
            c =>
            {
                c.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
    }
}