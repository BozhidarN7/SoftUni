using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerSOLID.Core.IO
{
    public class FileReader : IReader
    {
        private readonly string[] fileLines;
        private int pointer;
        public FileReader(string path = "../../../input.txt")
        {
            fileLines = File.ReadAllLines(path);
        }
        public string ReadLine()
        {
            return fileLines[pointer++];
        }
    }
}
