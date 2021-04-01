using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private readonly IWriter writer;
    public Engine()
    {
        writer = new FileWriter();
    }
    public void Run()
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        RaceTower raceTower = new RaceTower();
        raceTower.SetTrackInfo(numberOfLaps, trackLength);

        for (int i = 0; i < numberOfLaps; i++)
        {
            if(raceTower.LapsLeft == 0)
            {
                break;
            }
            string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];

            if (command == "RegisterDriver")
            {
                raceTower.RegisterDriver(tokens.Skip(1).ToList());
            }
            else if (command == "CompleteLaps")
            {
                string result = raceTower.CompleteLaps(tokens.Skip(1).ToList());
                writer.WriteLine(result);
            }
            else if(command == "Leaderboard")
            {
                string result = raceTower.GetLeaderboard();
                writer.WriteLine(result);
            }
            else if (command == "Box")
            {
                raceTower.DriverBoxes(tokens.Skip(1).ToList());
            }
            else if(command == "ChangeWeather")
            {
                raceTower.ChangeWeather(tokens.Skip(1).ToList());
            }
        }
        Driver winner = raceTower.GetAllDrivers.OrderByDescending(x => x.TotalTime).FirstOrDefault();
        if (winner == null)
        {
            winner = raceTower.GetOutOfRaceDrivers.Last();
        }
        writer.WriteLine(string.Format(ConstantMessages.WinnerMessage,winner.Name,winner.TotalTime));
        
    }
}

