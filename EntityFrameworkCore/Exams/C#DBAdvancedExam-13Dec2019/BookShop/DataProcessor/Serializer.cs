namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .ToArray()
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Books = a.AuthorsBooks
                    .Select(ab => ab.Book)
                    .OrderByDescending(b => b.Price)
                    .Select(ab => new
                    {
                        BookName = ab.Name,
                        BookPrice = ab.Price.ToString("f2"),
                    })
                    .ToArray()
                })
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();

            string json = JsonConvert.SerializeObject(authors, Formatting.Indented);
            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportBookDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportBookDto[] books = context.Books
                .ToArray()
                .Where(b => b.PublishedOn < date && b.Genre.ToString() == "Science")
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(b => new ExportBookDto()
                {
                    Pages = b.Pages.ToString(),
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToArray();

            StringBuilder result = new StringBuilder();
            using (StringWriter sw = new StringWriter(result))
            {
                serializer.Serialize(sw, books, namespaces);
            }

            return result.ToString().TrimEnd();
        }
    }
}