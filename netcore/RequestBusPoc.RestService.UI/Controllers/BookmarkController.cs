using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RequestBusPoc.Application;
using RequestBusPoc.Application.CreateBookmark;
using RequestBusPoc.Application.GetAllBookmarks;
using RequestBusPoc.Domain;

namespace RequestBusPoc.RestService.UI.Controllers
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

            return new JsonResult(bookmarks);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Bookmark bookmark)
        {
            CreateBookmarkRequest request = new CreateBookmarkRequest
            {
                FeatureId = bookmark.Url
            };
            requestBus.ProcessRequest<CreateBookmarkRequest, object>(request);

            return Ok();
        }
    }
}