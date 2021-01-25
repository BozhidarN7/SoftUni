using System;
using System.IO;

namespace _4.MergeFiles
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            using (StreamReader readerOne = new StreamReader(@"../../../../Resources/04.MergeFiles/FileOne.txt"))
            {
                using (StreamReader readerTwo = new StreamReader(@"../../../../Resources/04.MergeFiles/FileTwo.txt"))
                {
                    string lineOne = readerOne.ReadLine();
                    string lineTwo = readerTwo.ReadLine();
                    using (StreamWriter writer = new StreamWriter(@"../../../../Resources/04.MergeFiles/output.txt"))
                    {
                        while (lineOne != null && lineTwo != null)
                        {
                            writer.WriteLine(lineOne);
                            writer.WriteLine(lineTwo);

                            lineOne = readerOne.ReadLine();
                            lineTwo = readerTwo.ReadLine();
                        }
                    }
                }
            }
        }

    }
}