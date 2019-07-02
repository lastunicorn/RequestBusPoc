using RequestBusPoc.Domain;

namespace RequestBusPoc.RestService.Models
{
    public class BookmarkViewModel
    {
        public int Index { get; set; }
        public Bookmark Bookmark { get; set; }
    }
}