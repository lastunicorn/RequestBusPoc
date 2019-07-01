using System;
using RequestBusPoc.Domain;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.CreateBookmark
{
    public class CreateBookmarkRequestHandler : IRequestHandler<CreateBookmarkRequest, Bookmark>
    {
        private readonly IBookmarkRepository bookmarkRepository;

        public CreateBookmarkRequestHandler(IBookmarkRepository bookmarkRepository)
        {
            this.bookmarkRepository = bookmarkRepository ?? throw new ArgumentNullException(nameof(bookmarkRepository));
        }

        public Bookmark Handle(CreateBookmarkRequest request)
        {
            Bookmark bookmark = new Bookmark
            {
                Url = "http://" + request.FeatureId
            };
            bookmarkRepository.Add(bookmark);

            return bookmark;
        }
    }
}