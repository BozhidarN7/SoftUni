using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ShortestPath
{
    class ShortestPath
    {
        private static StringBuilder builder = new StringBuilder();

        private static char[] path;

        static void Main(string[] args)
        {
            path = Console.ReadLine().ToArray();
                
            char[] directions = new char[] { 'L', 'R', 'S' };
            int missedElements = path.Where(x => x == '*').Count();

            Generate(directions, new char[missedElements], 0);

            Console.WriteLine(Math.Pow(3,missedElements));
            Console.Write(builder);
        }

        private static void Generate(char[] directions, char[] missedParts, int index)
        {
            if (index >= missedParts.Length)
            {
                Print(missedParts, directions);
            }
            else
            {
                for (int i = 0; i < directions.Length; i++)
                {
                    missedParts[index] = directions[i];
                    Generate(directions, missedParts, index + 1);
                }


            }
        }

        private static void Print(char[] missedParts, char[] directioons)
        {
            int index = 0;

            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == '*')
                {
                    builder.Append(missedParts[index]);
                    index++;
                }
                else
                {
                    builder.Append(path[i]);
                }
            }

            builder.AppendLine();
        }
    }
}
