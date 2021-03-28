using HAD.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HAD.IO
{
    public class FileWriter : IWriter
    {
        private const string FilePath = "../../../log.txt";
        public void Flush()
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(FilePath,text);
            File.AppendAllText(FilePath,Environment.NewLine);
        }
    }
}
