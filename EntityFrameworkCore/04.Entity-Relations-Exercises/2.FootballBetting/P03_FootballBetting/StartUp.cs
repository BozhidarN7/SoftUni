using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;
using System;
using System.Collections.Generic;

namespace P03_FootballBetting
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext db = new FootballBettingContext();

            db.Database.Migrate();

            Console.WriteLine("Database created successfully!");
            
        }
    }
}
