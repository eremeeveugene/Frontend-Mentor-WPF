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
using FrontendMentor.GitHubUserSearchApp.BindableModels;
using FrontendMentor.GitHubUserSearchApp.Models.Navigation;
using FrontendMentor.GitHubUserSearchApp.Services.GitHubUsers;
using System.Windows.Input;

namespace FrontendMentor.GitHubUserSearchApp.ViewModels;

internal sealed class GitHubUserSearchAppViewModel(
    IContainerProvider containerProvider,
    IGitHubUsersService gitHubUsersService) : NavigationViewModelBase
{
    private GitHubUserBindableModel _gitHubUser = null!;
    private ICommand? _searchUserCommand;

    private string? _username;

    public ICommand SearchUserCommand => _searchUserCommand ??= new DelegateCommand(SearchUser);

    public string? Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    public GitHubUserBindableModel GitHubUser
    {
        get => _gitHubUser;
        set => SetProperty(ref _gitHubUser, value);
    }

    private async void SearchUser()
    {
        if (string.IsNullOrWhiteSpace(Username))
        {
            return;
        }

        try
        {
            var gitHubUser = await gitHubUsersService.GetUserAsync(Username);

            GitHubUser = GitHubUserBindableModel.Create(containerProvider,
                new GitHubUserBindableModel.Parameters(gitHubUser));

            //NameTextBlock.Text = $"Name: {user.Name}";
            //LoginTextBlock.Text = $"Username: {user.Login}";
            //ReposTextBlock.Text = $"Repositories: {user.PublicRepos}";
            //FollowersTextBlock.Text = $"Followers: {user.Followers} | Following: {user.Following}";

            //AvatarImage.Source = new BitmapImage(new Uri(user.AvatarUrl));
        }
        catch (Exception e)
        {
        }
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        var parameters = navigationContext.Parameters.GetValue<GitHubUserSearchAppNavigationParametersModel>(
            nameof(GitHubUserSearchAppNavigationParametersModel));

        GitHubUser = GitHubUserBindableModel.Create(containerProvider,
            new GitHubUserBindableModel.Parameters(parameters.GitHubUser));
    }
}