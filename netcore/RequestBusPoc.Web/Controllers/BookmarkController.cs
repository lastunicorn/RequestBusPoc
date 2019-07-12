using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RequestBusPoc.Application;
using RequestBusPoc.Application.GetAllBookmarks;
using RequestBusPoc.Domain;
using RequestBusPoc.Web.ViewModels;

namespace RequestBusPoc.Web.Controllers
{
    public class BookmarkController : Controller
    {
        private readonly ApplicationRequestBus requestBus;

        public BookmarkController(ApplicationRequestBus requestBus)
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