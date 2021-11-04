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

            //DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 9));
            //Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                 .ToList()
                 .Where(a => a.ProducerId == producerId)
                 .Select(a => new
                 {
                     AlbuName = a.Name,
                     ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                     ProdcuerName = a.Producer.Name,
                     Songs = a.Songs
                     .OrderByDescending(s => s.Name).ThenBy(s => s.Writer.Name)
                     .Select(s => new
                     {
                         SongName = s.Name,
                         Price = s.Price,
                         SongWriterName = s.Writer.Name,
                     })
                     .ToList()
                     .OrderByDescending(s => s.SongName)
                     .ThenBy(s => s.SongWriterName)
                     .ToList(),
                     AlbumPrice = a.Price
                 })
                 .ToList()
                 .OrderByDescending(a => a.AlbumPrice)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbuName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProdcuerName}");
                sb.AppendLine("-Songs:");

                int songNumber = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{songNumber++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().Trim();
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
