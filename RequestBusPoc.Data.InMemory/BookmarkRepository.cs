using System;
using System.Collections.Generic;
using RequestBusPoc.Domain;

namespace RequestBusPoc.Data.InMemory
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private static readonly List<Bookmark> Bookmarks = new List<Bookmark>();

        static BookmarkRepository()
        {
            Bookmarks.Add(new Bookmark { Url = "http://bookmark1" });
            Bookmarks.Add(new Bookmark { Url = "http://bookmark2" });
            Bookmarks.Add(new Bookmark { Url = "http://bookmark3" });
        }

        public void Add(Bookmark bookmark)
        {
            if (bookmark == null) throw new ArgumentNullException(nameof(bookmark));

            Bookmarks.Add(bookmark);
        }

        public IReadOnlyList<Bookmark> Get()
        {
            return Bookmarks.AsReadOnly();
        }
    }
}