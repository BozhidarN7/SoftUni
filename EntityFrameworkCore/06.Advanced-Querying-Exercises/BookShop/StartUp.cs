namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine();
            Console.WriteLine(GetBooksNotReleasedIn(db,int.Parse(command)));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            return string.Join(Environment.NewLine, context.Books
                 .Where(b => Enum.Parse<AgeRestriction>(command, true) == b.AgeRestriction)
                 .Select(b => b.Title)
                 .OrderBy(t => t)
                 .ToList());
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            return string.Join(Environment.NewLine, context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            return string.Join(Environment.NewLine, context.Books.
                Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToList());
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            return string.Join(Environment.NewLine, context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList());
        }
    }
}
