using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Enums;
using _7.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = string.Empty;
                string lastname = string.Empty;
                string id = string.Empty;
                decimal salary = 0m;
                if (tokens[0] == "Private")
                {
                    SetTokens(tokens, ref firstName, ref lastname, ref id, ref salary);
                    soldiers.Add(new Private(id, firstName, lastname, salary));
                }
                else if (tokens[0] == "LieutenantGeneral")
                {
                    SetTokens(tokens, ref firstName, ref lastname, ref id, ref salary);
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastname, salary);
                    for (int i = 5; i < tokens.Length; i++)
                    {
                        IPrivate @private = (IPrivate)soldiers.FirstOrDefault(x => x.Id == tokens[i]);
                        if (@private != null)
                        {
                            lieutenantGeneral.AddPrivate(@private);
                        }
                    }
                    soldiers.Add(lieutenantGeneral);
                }
                else if (tokens[0] == "Engineer")
                {
                    SetTokens(tokens, ref firstName, ref lastname, ref id, ref salary);
                    bool isCorpseValid = Enum.TryParse(tokens[5], out Corps corps);
                    if (!isCorpseValid)
                    {
                        line = Console.ReadLine();
                        continue;
                    }
                    IEngineer engineer = new Engineer(id, firstName, lastname, salary, corps);
                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        engineer.AddRepair(new Repair(tokens[i], int.Parse(tokens[i + 1])));
                    }
                    soldiers.Add((ISoldier)engineer);
                }
                else if (tokens[0] == "Commando")
                {
                    SetTokens(tokens, ref firstName, ref lastname, ref id, ref salary);
                    bool isCorpseValid = Enum.TryParse(tokens[5], out Corps corps);
                    if (!isCorpseValid)
                    {
                        line = Console.ReadLine();
                        continue;
                    }
                    ICommando commando = new Commando(id, firstName, lastname, salary, corps);
                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        bool isMissionValid = Enum.TryParse(tokens[i + 1], out MissionState ms);
                        if (!isMissionValid)
                        {
                            continue;
                        }
                        commando.AddMission(new Mission(tokens[i], ms));
                    }
                    soldiers.Add((ISoldier)commando);
                }
                else
                {
                    id = tokens[1];
                    firstName = tokens[2];
                    lastname = tokens[3];
                    int codeNumber = int.Parse(tokens[4]);
                    soldiers.Add(new Spy(id, firstName, lastname, codeNumber));
                }
                line = Console.ReadLine();
            }
            soldiers.ForEach(x => Console.WriteLine(x));
        }

        private static void SetTokens(string[] tokens, ref string firstName, ref string lastname, ref string id, ref decimal salary)
        {
            id = tokens[1];
            firstName = tokens[2];
            lastname = tokens[3];
            salary = decimal.Parse(tokens[4]);
        }
    }
}