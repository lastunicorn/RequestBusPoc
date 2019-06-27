using System;
using RequestBusPoc.Cli.UI.ViewModels;

namespace RequestBusPoc.Cli.UI.Views
{
    internal class CreateBookmarkView
    {
        private readonly CreateBookmarkViewModel viewModel;

        public CreateBookmarkView(CreateBookmarkViewModel viewModel)
        {
            this.viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public void Display()
        {
            if (viewModel.IsSuccess)
            {
                Console.WriteLine("Bookmark was successfully created.");
                Console.WriteLine("The bookmark url: " + viewModel.Url);
            }
            else
            {
                Console.WriteLine("Bookmark was NOT created.");
            }
        }
    }
}