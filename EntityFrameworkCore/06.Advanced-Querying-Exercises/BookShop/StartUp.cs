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
            Console.WriteLine(GetBooksByAgeRestriction(db, command));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            return string.Join(Environment.NewLine, context.Books
                 .Where(b => Enum.Parse<AgeRestriction>(command, true) == b.AgeRestriction)
                 .Select(b => b.Title)
                 .OrderBy(t => t)
                 .ToList());
        }
    }
}
