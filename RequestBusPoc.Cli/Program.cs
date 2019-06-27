using System;
using Ninject;
using RequestBusPoc.Cli.UI.Controllers;

namespace RequestBusPoc.Presentation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                IKernel kernel = Setup.SetupDependencyResolver();

                CreateBookmark1(kernel);
                CreateBookmark2(kernel);
                DisplayBookmarks(kernel);
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }

            DisplayPause();
        }

        private static void DisplayException(Exception exception)
        {
            Console.WriteLine(exception);
        }

        private static void DisplayPause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        private static void CreateBookmark1(IKernel kernel)
        {
            BookmarkController bookmarkController = kernel.Get<BookmarkController>();
            bookmarkController.CreateBookmark("feature 1");
        }

        private static void CreateBookmark2(IKernel kernel)
        {
            BookmarkController bookmarkController = kernel.Get<BookmarkController>();
            bookmarkController.CreateBookmark("feature 2");
        }

        private static void DisplayBookmarks(IKernel kernel)
        {
            BookmarkController bookmarkController = kernel.Get<BookmarkController>();
            bookmarkController.DisplayBookmarks();
        }
    }
}