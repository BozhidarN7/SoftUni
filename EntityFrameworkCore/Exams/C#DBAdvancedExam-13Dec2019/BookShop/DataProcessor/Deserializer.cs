namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportBookDto[]), xmlRoot);

            ImportBookDto[] booksDto = null;
            using (StringReader sr = new StringReader(xmlString))
            {
                booksDto = (ImportBookDto[])serializer.Deserialize(sr);
            }

            StringBuilder result = new StringBuilder();
            HashSet<Book> books = new HashSet<Book>();

            foreach (ImportBookDto bookDto in booksDto)
            {
                if (!IsValid(bookDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (bookDto.Genre < 1 || bookDto.Genre > 3)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book()
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = date
                };

                books.Add(book);
                result.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }
            context.Books.AddRange(books);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            ImportAuthorDto[] authorsDto = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            StringBuilder result = new StringBuilder();
            HashSet<Author> authors = new HashSet<Author>();

            foreach (ImportAuthorDto authorDto in authorsDto)
            {
                if (!IsValid(authorDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
               

                Author author = context.Authors.FirstOrDefault(a => a.Email == authorDto.Email);
                if (author != null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                HashSet<AuthorBook> authorBooks = new HashSet<AuthorBook>();
                foreach (ImportAuthorBookDto authorBookDto in authorDto.Books)
                {
                    if (!authorBookDto.Id.HasValue) continue;

                    Book book = context.Books.Find(authorBookDto.Id.Value);
                    if (book == null)
                    {
                        continue;
                    }
                    authorBooks.Add(new AuthorBook()
                    {
                        BookId = authorBookDto.Id.Value,
                        Book = book
                    });
                }
                if (authorBooks.Count == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone,
                    AuthorsBooks = authorBooks
                };
                authors.Add(author);
                result.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{author.FirstName} {author.LastName}", author.AuthorsBooks.Count));
            }
            context.Authors.AddRange(authors);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}