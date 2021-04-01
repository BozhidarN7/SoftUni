namespace Bakery.IO
{
    using Bakery.IO.Contracts;
    using System;
    using System.IO;
    using System.Text;

    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
