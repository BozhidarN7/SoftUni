namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine();
            Console.WriteLine(GetAuthorNamesEndingIn(db, command));
            //IncreasePrices(db);
            //Console.WriteLine(RemoveBooks(db));
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
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", null))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList());
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine, context.Authors
                .ToList()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
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

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                //.Include(c => c.CategoryBooks)
                //.ThenInclude(cb => cb.Book)
                //.ToList()
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .Select(cb => cb.Book
                    )
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.Append($"--{category.Name}\r\n");

                foreach (var book in category.Books)
                {
                    sb.Append($"{book.Title} ({book.ReleaseDate.Value.Year})\r\n");
                }
            }

            return sb.ToString().Trim();

        }

        public static void IncreasePrices(BookShopContext context)
        {
            List<Book> books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (Book book in books)
            {
                book.Price += 5;


            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            List<Book> books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }
}
