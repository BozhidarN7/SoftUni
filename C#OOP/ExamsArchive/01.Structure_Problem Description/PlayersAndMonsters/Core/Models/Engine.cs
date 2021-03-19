using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.IO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Models
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            IManagerController managerController = new ManagerController();
            string line = reader.ReadLine();
            while (line != "Exit")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                try
                {
                    if (command == "AddPlayer")
                    {
                        writer.WriteLine(managerController.AddPlayer(tokens[1], tokens[2]));
                    }
                    else if (command == "AddCard")
                    {
                        writer.WriteLine(managerController.AddCard(tokens[1], tokens[2]));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        writer.WriteLine(managerController.AddPlayerCard(tokens[1], tokens[2]));
                    }
                    else if (command == "Fight")
                    {
                        writer.WriteLine(managerController.Fight(tokens[1], tokens[2]));
                    }
                    else if (command == "Report")
                    {
                        writer.WriteLine(managerController.Report());
                    }
                }catch(ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                line = reader.ReadLine();
            }
        }
    }
}
