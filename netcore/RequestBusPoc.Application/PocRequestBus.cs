using RequestBusPoc.Application.CreateBookmark;
using RequestBusPoc.Application.GetAllBookmarks;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.Application
{
    public class ApplicationRequestBus : RequestBus
    {
        public ApplicationRequestBus(IRequestHandlerFactory handlerFactory)
            :base(handlerFactory)
        {
            Register<CreateBookmarkRequest, CreateBookmarkRequestHandler>();
            Register<GetAllBookmarksRequest, GetAllBookmarksRequestHandler>();
        }
    }
}