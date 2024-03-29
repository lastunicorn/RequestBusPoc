﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RequestBusPoc.Domain;
using RequestBusPoc.GetAllBookmarks;
using RequestBusPoc.Web.ViewModels;

namespace RequestBusPoc.Web.Controllers
{
    public class BookmarkController : Controller
    {
        private readonly RequestBus requestBus;

        public BookmarkController(RequestBus requestBus)
        {
            this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        // GET: Bookmark
        public ActionResult Index()
        {
            GetAllBookmarksRequest request = new GetAllBookmarksRequest();
            List<Bookmark> bookmarks = requestBus.ProcessRequest<GetAllBookmarksRequest, List<Bookmark>>(request);

            BookmarksViewModel viewModel = new BookmarksViewModel(bookmarks);
            return View(viewModel);
        }
    }
}