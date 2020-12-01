using System;
using System.Text;
using System.Linq;
namespace _7.StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int previous = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (previous > 0 && input[i] != '>')
                {
                    input = input.Remove(i, 1);
                    previous--;
                    i--;
                }
                else if (input[i] == '>')
                {
                    previous += int.Parse(input[i + 1].ToString());
                }
            }
            Console.WriteLine(input);
        }
    }
}
