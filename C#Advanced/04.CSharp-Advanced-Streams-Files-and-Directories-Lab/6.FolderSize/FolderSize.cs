using System;
using System.IO;

namespace _6.FolderSize
{
    class FolderSize
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"../../../../Resources/06.FolderSize/TestFolder");
            double sum = 0;
            foreach(string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;
            File.WriteAllText(@"../../../../Resources/06.FolderSize/TestFolder/output.txt", sum.ToString());
        }
    }
}
