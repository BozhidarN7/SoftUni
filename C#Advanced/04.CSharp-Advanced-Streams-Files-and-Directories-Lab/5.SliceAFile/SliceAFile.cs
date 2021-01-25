using System;
using System.IO;
using System.Linq;

namespace _5.SliceAFile
{
    class SliceAFile
    {
        static void Main(string[] args)
        {
            int parts = 4;
            using (FileStream streamReader = new FileStream(@"../../../../Resources/05.SliceFile/sliceMe.txt", FileMode.Open))
            {
                long partSize = (long)Math.Ceiling((double)streamReader.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    using (FileStream streamWriter = new FileStream(@$"../../../../Resources/05.SliceFile/Part-{i + 1}.txt", FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[40196];
                        while (streamReader.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            currentPieceSize += buffer.Length;
                            streamWriter.Write(buffer, 0, buffer.Length);
                            if(currentPieceSize >= partSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
