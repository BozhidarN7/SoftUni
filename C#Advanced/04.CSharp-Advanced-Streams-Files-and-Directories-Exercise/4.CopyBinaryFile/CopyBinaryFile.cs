using System;
using System.IO;

namespace _4.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream(@"../../../../copyMe.png", FileMode.Open))
            {
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                using (FileStream writer = new FileStream(@"../../../../output.png", FileMode.Create, FileAccess.Write))
                {
                    while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
