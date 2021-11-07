namespace MusicHub
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 9));
            //Console.WriteLine(ExportSongsAboveDuration(context, 4));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albumsInfo = context
                .Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .ToArray()
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("f2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    TotalAlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();

            foreach (var album in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int i = 1;
                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{i++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price}")
                        .AppendLine($"---Writer: {song.Writer}");
                }

                sb
                    .AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
               .Where(s => s.Duration.TotalSeconds > duration)
               .Select(s => new
               {
                   Writer = s.Writer.Name,
                   Performer = s.SongPerformers
                       .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                       .FirstOrDefault(),
                   SongName = s.Name,
                   AlbumProducer = s.Album.Producer.Name,
                   Duration = s.Duration
               })
               .ToList()
               .OrderBy(s => s.SongName)
               .ThenBy(s => s.Writer)
               .ThenBy(s => s.Performer)
               .ToList();

            StringBuilder sb = new StringBuilder();

            var i = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{i}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");

                i++;
            }

            return sb.ToString().Trim();
        }
    }
}
