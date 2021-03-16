 using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerSOLID.Loggers
{
    public interface ILogFile
    {
        public int Size { get; }
        public void Write(string content);
    }
}
