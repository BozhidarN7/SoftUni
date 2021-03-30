using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosX.IO.Contracts
{
    public class StringBuilderWriter : IWriter
    {
        public StringBuilder sb = new StringBuilder();
        
        public void WriteLine(string output)
        {
            sb.AppendLine(output);
        }
    }
}
