namespace TheTankGame.IO
{
    using System;
    using System.Text;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        //public StringBuilder result = new StringBuilder();
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
            //result.AppendLine(output);
        }
    }
}