using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine : IEngine
{
    private readonly INationsBuilder nationBuilder;
    private readonly IWriter writer;
    private readonly IReader reader;
    public Engine()
    {
        nationBuilder = new NationsBuilder();
        writer = new FileWriter();
        reader = new ConsoleReader();
    }
    public void Run()
    {
        while (true)
        {
            string[] tokens = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = tokens[0];
            List<string> args = tokens.Skip(1).ToList();

            if (command == "Bender")
            {
                nationBuilder.AssignBender(args);
            }
            else if(command == "Monument")
            {
                nationBuilder.AssignMonument(args);
            }
            else if(command == "Status")
            {
                string result = nationBuilder.GetStatus(args[0]);
                writer.WriteLine(result);
            }
            else if(command == "War")
            {
                nationBuilder.IssueWar(args[0]);
            }
            else if(command == "Quit")
            {
                string result = nationBuilder.GetWarsRecord();
                writer.WriteLine(result);
                break;
            }
        }
    }
}

