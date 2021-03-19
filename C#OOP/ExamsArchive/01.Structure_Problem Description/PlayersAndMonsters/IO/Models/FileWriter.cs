using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlayersAndMonsters.IO.Models
{
    public class FileWriter : IWriter
    {
        private const string FilePath = "../../../log.txt";
        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(FilePath,message +Environment.NewLine);
        }
    }
}
