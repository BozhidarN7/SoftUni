using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5.DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> result = new Dictionary<string, Dictionary<string, double>>();

            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!result.ContainsKey(fileInfo.Extension))
                {
                    result.Add(fileInfo.Extension, new Dictionary<string, double>());
                }
                result[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length / 1024.0);
            }

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter writer = new StreamWriter($"{pathToDesktop}/report.txt"))
            {
                foreach((string extension,Dictionary<string,double> file) in result.OrderByDescending(x => x.Value.Keys.Count).ThenBy(x => x.Key))
                {
                    writer.WriteLine(extension);
                    foreach((string name, double size) in file.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{name} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
