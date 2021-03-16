using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerSOLID.Loggers
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";
        public int Size => File.ReadAllText(FilePath)
            .Where(x => char.IsLetter(x)).Sum(x => x);

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
