using RequestBusPoc.CreateBookmark;
using RequestBusPoc.Domain.RequestBusModel;
using RequestBusPoc.GetAllBookmarks;

namespace RequestBusPoc
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