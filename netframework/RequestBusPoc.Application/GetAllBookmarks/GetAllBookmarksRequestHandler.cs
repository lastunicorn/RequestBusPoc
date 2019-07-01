using System;
using System.Collections.Generic;
using System.Linq;
using RequestBusPoc.Domain;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.GetAllBookmarks
{
    public class GetAllBookmarksRequestHandler : IRequestHandler<GetAllBookmarksRequest, List<Bookmark>>
    {
        private readonly IBookmarkRepository bookmarkRepository;

        public GetAllBookmarksRequestHandler(IBookmarkRepository bookmarkRepository)
        {
            this.bookmarkRepository = bookmarkRepository ?? throw new ArgumentNullException(nameof(bookmarkRepository));
        }

        public List<Bookmark> Handle(GetAllBookmarksRequest request)
        {
            return bookmarkRepository.Get().ToList();
        }
    }
}