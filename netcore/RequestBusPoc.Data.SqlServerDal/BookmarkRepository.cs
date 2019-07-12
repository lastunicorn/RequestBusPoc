using System;
using System.Collections.Generic;
using System.Linq;
using RequestBusPoc.Domain;

namespace RequestBusPoc.Data.SqlServerDal
{
    // https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio

    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly ELearningContext context;

        public BookmarkRepository(ELearningContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Bookmark bookmark)
        {
            context.Bookmarks.Add(bookmark);
            context.SaveChanges();
        }

        public IReadOnlyList<Bookmark> Get()
        {
            return context.Bookmarks.ToList();
        }
    }
}