using System;
using RequestBusPoc.Cli.UI.ViewModels;

namespace RequestBusPoc.Cli.UI.Views
{
    internal class BookmarksView
    {
        private readonly BookmarksViewModel viewModel;

        public BookmarksView(BookmarksViewModel viewModel)
        {
            this.viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("The list of bookmarks:");

            foreach (BookmarkViewModel bookmark in viewModel.Bookmarks)
            {
                Console.WriteLine("{0} - {1}", bookmark.Index, bookmark.Bookmark.Url);
            }
        }
    }
}