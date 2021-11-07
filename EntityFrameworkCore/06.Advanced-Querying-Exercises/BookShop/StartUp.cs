namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string command = Console.ReadLine();
            Console.WriteLine(GetTotalProfitByCategory(db));
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

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            return string.Join(Environment.NewLine, context.Books
                .ToList()
                .Where(b =>
                {
                    int result = DateTime.Compare(b.ReleaseDate.Value, DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture));
                    if (result <= 0)
                    {
                        return true;
                    }
                    return false;
                })
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList());
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine, context.Authors
                .ToList()
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .OrderBy(a => a.FirstName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToList());
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine, context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList());
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine, context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList());
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            return string.Join(Environment.NewLine, context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .Select(a => $"{a.FirstName} {a.LastName} - {a.TotalCopies}")
                .ToList());
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            return string.Join(Environment.NewLine, context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .Select(c => $"{c.Name} ${c.Profit:f2}")
                .ToList());
        }
    }
}
