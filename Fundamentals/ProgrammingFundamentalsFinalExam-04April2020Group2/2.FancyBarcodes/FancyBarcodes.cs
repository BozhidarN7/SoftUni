using System;
using System.Text.RegularExpressions;

namespace _2.FancyBarcodes
{
    class FancyBarcodes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex pattern = new Regex(@"@#{1,}[A-Z][A-Za-z0-9]{4,}[A-Z]@#{1,}");
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                if (pattern.Match(barcode).Success)
                {
                    bool containsNumber = false;
                    Console.Write("Product group: ");
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (barcode[j] >= '0' && barcode[j] <= '9')
                        {
                            containsNumber = true;
                            Console.Write(barcode[j]);
                        }
                    }
                    if (!containsNumber)
                    {
                        Console.Write("00");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
