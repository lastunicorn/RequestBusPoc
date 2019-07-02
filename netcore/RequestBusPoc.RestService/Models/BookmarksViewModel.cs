using System.Collections.Generic;
using System.Linq;
using RequestBusPoc.Domain;

namespace RequestBusPoc.RestService.Models
{
    public class BookmarksViewModel : List<BookmarkViewModel>
    {
        public BookmarksViewModel(IEnumerable<Bookmark> bookmarks)
        {
            IEnumerable<BookmarkViewModel> b = bookmarks
                .Select((x, i) => new BookmarkViewModel
                {
                    Index = i,
                    Bookmark = x
                });

            AddRange(b);
        }
    }
}