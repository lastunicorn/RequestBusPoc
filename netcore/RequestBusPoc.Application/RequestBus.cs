using RequestBusPoc.Application.CreateBookmark;
using RequestBusPoc.Application.GetAllBookmarks;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.Application
{
    public class RequestBus : RequestBusBase
    {
        public RequestBus(IRequestHandlerFactory handlerFactory)
            :base(handlerFactory)
        {
            Register<CreateBookmarkRequest, CreateBookmarkRequestHandler>();
            Register<GetAllBookmarksRequest, GetAllBookmarksRequestHandler>();
        }
    }
}