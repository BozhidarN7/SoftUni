using System;

namespace _3.ExtractFile
{
    class ExtractFile
    {
        static void Main(string[] args)
        {
            string file = Console.ReadLine();
            int dotIndex = file.IndexOf('.');
            int lastSlash = file.LastIndexOf('\\');
            string fileName = file.Substring(lastSlash + 1, dotIndex - lastSlash - 1);
            string fileExtension = file.Substring(dotIndex + 1, file.Length - dotIndex - 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
