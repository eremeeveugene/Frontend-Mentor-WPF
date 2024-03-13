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

using FrontendMentor.BlogPreviewCard.Models;
using System.Globalization;

namespace FrontendMentor.BlogPreviewCard.Services.Blogs;

internal class BlogsService : IBlogsService
{
    public BlogModel GetBlog()
    {
        return new BlogModel
        {
            Category = "Learning",
            Title = "HTML & CSS foundations",
            Description =
                "These languages are the backbone of every website, defining structure, content, and presentation.",
            ImageUriString = "Images/BlogImage.png",
            PublishedDate =
                DateTime.ParseExact("21.12.2023", "dd.MM.yyyy", CultureInfo.CurrentUICulture, DateTimeStyles.None),
            BlogAuthor = new BlogAuthorModel
            {
                FirstName = "Greg", LastName = "Hooper", ImageUriString = "Images/UserImage.webp"
            }
        };
    }
}