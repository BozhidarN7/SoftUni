namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(db, command));
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

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split(" ").ToList();

            return String.Join(Environment.NewLine, context.Books
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .ToList()
                .Where(b =>
                {
                    bool categoryMatch = false;
                    foreach (string category in categories)
                    {
                        if (b.BookCategories.Any(c => c.Category.Name.ToLower() == category.ToLower()))
                        {
                            categoryMatch = true;
                        }
                    }
                    return categoryMatch;
                })
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList());
        }
    }
}
