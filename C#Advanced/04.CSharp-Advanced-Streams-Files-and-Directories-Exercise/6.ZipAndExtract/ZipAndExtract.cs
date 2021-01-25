using System;
using System.IO;
using System.IO.Compression;

namespace _6.ZipAndExtract
{
    class ZipAndExtract
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"../../../../ZippedFiles");
            Directory.CreateDirectory(@"../../../../ExtractedFiles");
            File.Move(@"../../../../copyMe.png", @"../../../../ZippedFiles/copyMe.png");
            ZipFile.CreateFromDirectory(@"../../../../ZippedFiles", @"../../../../Zipped.zip");
            ZipFile.ExtractToDirectory(@"../../../../Zipped.zip", @"../../../../ExtractedFiles");
        }
    }
}
