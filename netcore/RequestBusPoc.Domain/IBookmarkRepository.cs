using System.Collections.Generic;

namespace RequestBusPoc.Domain
{
    public interface IBookmarkRepository
    {
        void Add(Bookmark bookmark);
        IReadOnlyList<Bookmark> Get();
    }
}