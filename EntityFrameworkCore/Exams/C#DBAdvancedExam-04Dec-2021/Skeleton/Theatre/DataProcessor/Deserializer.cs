namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);
            ImportPlayDto[] playsDto = (ImportPlayDto[])serializer.Deserialize(sr);

            StringBuilder result = new StringBuilder();
            HashSet<Play> plays = new HashSet<Play>();

            foreach (ImportPlayDto playDto in playsDto)
            {
                if (!IsValid(playDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse(playDto.Genre, out Genre genre);
                if (!isGenreValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, out TimeSpan duration);
                if (!isDurationValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.Hours < 1)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter,
                };

                plays.Add(play);
                result.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);
            ImportCastDto[] castsDto = (ImportCastDto[])serializer.Deserialize(sr);

            StringBuilder result = new StringBuilder();
            HashSet<Cast> casts = new HashSet<Cast>();

            foreach (ImportCastDto castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId,
                };

                result.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
                casts.Add(cast);
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportTheatreDto[] theatresDto = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            StringBuilder result = new StringBuilder();
            HashSet<Theatre> theatres = new HashSet<Theatre>();

            foreach (ImportTheatreDto theatreDto in theatresDto)
            {
                if (!IsValid(theatreDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                //bool areAllPlaysValid = true;
                HashSet<Ticket> tickets = new HashSet<Ticket>();

                foreach (ImportTicketDto ticketDto in theatreDto.Tickets)
                {
                    //Play play = context.Plays.Find(ticketDto.PlayId);

                    //if (play == null)
                    //{
                    //    //areAllPlaysValid = false;
                    //    result.AppendLine(ErrorMessage);
                    //    continue;
                    //    //break;
                    //}

                    if (!IsValid(ticketDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };
                    tickets.Add(ticket);
                }

                //if (!areAllPlaysValid)
                //{
                //    result.AppendLine(ErrorMessage);
                //    continue;
                //}

                Theatre theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                    Tickets = tickets
                };

                theatres.Add(theatre);
                result.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
