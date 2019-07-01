using System.Collections.Generic;
using System.Linq;
using RequestBusPoc.Domain;

namespace RequestBusPoc.Cli.UI.ViewModels
{
    internal class BookmarksViewModel
    {
        public List<BookmarkViewModel> Bookmarks { get; set; }

        public BookmarksViewModel(IEnumerable<Bookmark> bookmarks)
        {
            Bookmarks = bookmarks
                .Select((x, i) => new BookmarkViewModel
                {
                    Index = i,
                    Bookmark = x
                })
                .ToList();
        }
    }
}