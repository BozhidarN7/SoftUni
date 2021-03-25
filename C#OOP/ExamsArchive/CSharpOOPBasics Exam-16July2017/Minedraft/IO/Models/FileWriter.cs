using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class FileWriter : IWriter
{
    public const string FilePath = "../../../log.txt";
    public void WriteLine(string text)
    {
        File.AppendAllText(FilePath,text);
        File.AppendAllText(FilePath, Environment.NewLine);
    }
}
