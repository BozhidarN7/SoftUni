using AquaShop.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AquaShop.IO
{
    public class FileWriter : IWriter
    {
        private const string FilePath = "../../../log.txt";
        public void Write(string message)
        {
            File.AppendAllText(FilePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(FilePath, message + Environment.NewLine);
        }

    }
}
