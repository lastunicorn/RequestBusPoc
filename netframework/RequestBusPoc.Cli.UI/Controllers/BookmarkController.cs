﻿using System;
using System.Collections.Generic;
using RequestBusPoc.Cli.UI.ViewModels;
using RequestBusPoc.Cli.UI.Views;
using RequestBusPoc.CreateBookmark;
using RequestBusPoc.Domain;
using RequestBusPoc.GetAllBookmarks;

namespace RequestBusPoc.Cli.UI.Controllers
{
    public class BookmarkController
    {
        private readonly RequestBus requestBus;

        public BookmarkController(RequestBus requestBus)
        {
            this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void CreateBookmark(string featureId)
        {
            CreateBookmarkRequest request = new CreateBookmarkRequest
            {
                FeatureId = featureId
            };

            Bookmark bookmark = requestBus.ProcessRequest<CreateBookmarkRequest, Bookmark>(request);

            CreateBookmarkViewModel viewModel = new CreateBookmarkViewModel
            {
                IsSuccess = true,
                Url = bookmark.Url
            };

            CreateBookmarkView view = new CreateBookmarkView(viewModel);
            view.Display();
        }

        public void DisplayBookmarks()
        {
            GetAllBookmarksRequest request = new GetAllBookmarksRequest();
            List<Bookmark> bookmarks = requestBus.ProcessRequest<GetAllBookmarksRequest, List<Bookmark>>(request);

            BookmarksViewModel viewModel = new BookmarksViewModel(bookmarks);

            BookmarksView view = new BookmarksView(viewModel);
            view.Display();
        }
    }
}