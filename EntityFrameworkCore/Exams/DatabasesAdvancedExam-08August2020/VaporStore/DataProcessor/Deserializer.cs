namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfullyImportedGameMessage = "Added {0} ({1}) with {2} tags";
        private const string SuccessfullyImportedUsermessage = "Imported {0} with {1} cards";
        private const string SuccessfullyImportedPurchaseMessage = "Imported {0} for {1}";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            ImportGameDto[] gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            StringBuilder result = new StringBuilder();

            HashSet<Game> games = new HashSet<Game>();
            HashSet<Developer> developers = new HashSet<Developer>();
            HashSet<Genre> genres = new HashSet<Genre>();
            HashSet<Tag> tags = new HashSet<Tag>();

            foreach (ImportGameDto gameDto in gamesDto)
            {
                if (!IsValid(gameDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Price < 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidReleaseDate = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime releaseDate);

                if (!isValidReleaseDate)
                {
                    result.Append(ErrorMessage);
                    continue;
                }

                Game game = new Game()
                {
                    Name = gameDto.Name,
                    ReleaseDate = releaseDate,
                    Price = gameDto.Price,
                };

                Developer developer = developers.FirstOrDefault(d => gameDto.Developer == d.Name);
                if (developer == null)
                {
                    developer = new Developer()
                    {
                        Name = gameDto.Developer
                    };
                    developers.Add(developer);
                    game.Developer = developer;
                }
                else
                {
                    game.Developer = developer;
                }

                Genre genre = genres.FirstOrDefault(g => gameDto.Genre == g.Name);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = gameDto.Genre
                    };
                    genres.Add(genre);
                    game.Genre = genre;
                }
                else
                {
                    game.Genre = genre;
                }

                foreach (string tagName in gameDto.Tags)
                {
                    if (string.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    Tag tag = tags.FirstOrDefault(t => t.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag()
                        {
                            Name = tagName
                        };
                        tags.Add(tag);
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = tag
                        });
                    }
                    else
                    {
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = tag
                        });
                    }
                }

                if (game.GameTags.Count == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(game);

                result.AppendLine(string.Format(SuccessfullyImportedGameMessage, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            ImportUserDto[] usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            StringBuilder result = new StringBuilder();

            HashSet<User> users = new HashSet<User>();

            foreach (ImportUserDto userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool areAllCardsValid = true;

                foreach (ImportUserCardDto cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        areAllCardsValid = false;
                        break;
                    }
                }

                if (!areAllCardsValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                };

                HashSet<Card> cards = new HashSet<Card>();
                foreach (ImportUserCardDto cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        areAllCardsValid = false;
                        break;
                    }

                    bool isValidCardType = Enum.TryParse(cardDto.Type, out CardType type);
                    if (!isValidCardType)
                    {
                        areAllCardsValid = false;
                        break;
                    }

                    Card card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = type,
                        User = user,
                        UserId = user.Id
                    };

                    cards.Add(card);
                }
                user.Cards = cards;
                users.Add(user);

                result.AppendLine(string.Format(SuccessfullyImportedUsermessage, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportPurchaseDto[] purchasesDto = (ImportPurchaseDto[])serializer.Deserialize(sr);

            HashSet<Purchase> purchases = new HashSet<Purchase>();

            StringBuilder result = new StringBuilder();

            foreach (ImportPurchaseDto purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isPurchaseValidType = Enum.TryParse(purchaseDto.Type, out PurchaseType type);

                if (!isPurchaseValidType)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);
                if (card == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                if (game == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Type = type,
                    Date = date,
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Game = game
                };

                purchases.Add(purchase);

                result.AppendLine(string.Format(SuccessfullyImportedPurchaseMessage, purchase.Game.Name, purchase.Card.User.Username));
            }

            context.AddRange(purchases);
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