using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RequestBusPoc.Application;
using RequestBusPoc.Application.GetAllBookmarks;
using RequestBusPoc.Domain;
using RequestBusPoc.RestService.Models;

namespace RequestBusPoc.RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly RequestBus requestBus;

        public BookmarkController(RequestBus requestBus)
        {
            this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        [HttpGet]
        public JsonResult Get()
        {
            GetAllBookmarksRequest request = new GetAllBookmarksRequest();
            List<Bookmark> bookmarks = requestBus.ProcessRequest<GetAllBookmarksRequest, List<Bookmark>>(request);

            BookmarksViewModel viewModel = new BookmarksViewModel(bookmarks);
            return new JsonResult(viewModel);
        }
    }
}