using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Engine : IEngine
{
    private readonly IDraftManager draftManager;
    private readonly IWriter writer;
    private readonly IReader reader;
    public Engine()
    {
        draftManager = new DraftManager();
        writer = new ConsoleWriter();
        reader = new ConsoleReader();
    }
    public void Run()
    {
        while (true)
        {
            string[] tokens = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            List<string> args = tokens.Skip(1).ToList();

            if (command == "RegisterHarvester")
            {
                string result = draftManager.RegisterHarvester(args);
                writer.WriteLine(result);
            }
            else if (command == "RegisterProvider")
            {
                string result = draftManager.RegisterProvider(args);
                writer.WriteLine(result);
            }
            else if (command == "Day")
            {
                string result = draftManager.Day();
                writer.WriteLine(result);
            }
            else if (command == "Check")
            {
                string result = draftManager.Check(args);
                writer.WriteLine(result);
            }
            else if(command =="Mode")
            {
                string result = draftManager.Mode(args);
                writer.WriteLine(result);
            }    
            else if(command == "Shutdown")
            {
                string reslut = draftManager.ShutDown();
                writer.WriteLine(reslut);
                break;
            }
        }
    }
}

