using EasterRaces.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.IO
{
    public class StringBuilderWriter : IWriter
    {
        private StringBuilder sb;

        public StringBuilderWriter()
        {
            sb = new StringBuilder();
        }
        public void Write(string message)
        {
            sb.Append(message);
        }

        public void WriteLine(string message)
        {
            sb.AppendLine(message);
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
