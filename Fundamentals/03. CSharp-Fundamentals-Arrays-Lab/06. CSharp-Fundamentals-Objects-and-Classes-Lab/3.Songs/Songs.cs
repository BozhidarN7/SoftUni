using System;
using System.Collections.Generic;

namespace _3.Songs
{
    class Songs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('_');
                songs.Add(new Song { TypeList = input[0], Name = input[1], Time = input[2] });
            }

            string typeList = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                if (songs[i].TypeList == typeList || typeList == "all")
                {
                    Console.WriteLine(songs[i].Name);
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
