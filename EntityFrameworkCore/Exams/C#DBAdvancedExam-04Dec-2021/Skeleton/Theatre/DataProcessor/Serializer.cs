namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5).Sum(ti => ti.Price),
                    Tickets = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Select(ti => new
                        {
                            Price = ti.Price,
                            RowNumber = ti.RowNumber
                        })
                        .OrderByDescending(ti => ti.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            string json = JsonConvert.SerializeObject(theaters, Formatting.Indented);

            return json.TrimEnd();
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder result = new StringBuilder();
            using StringWriter sw = new StringWriter(result);

            ExportPlayDto[] plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ExportPlayActorDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()

                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            xmlSerializer.Serialize(sw, plays, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}
