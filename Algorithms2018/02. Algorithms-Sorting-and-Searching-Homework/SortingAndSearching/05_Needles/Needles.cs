using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Needles
{
    class _05_Needles
    {
        private static List<int> result = new List<int>();

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] needles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (var needle in needles)
            {
                bool match = false;

                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] >= needle)
                    {
                        if (i > 0 && elements[i - 1] == 0)
                        {
                            int index = i;

                            while (index != 0)
                            {
                                if (elements[index - 1] != 0)
                                {
                                    result.Add(index);
                                    match = true;
                                    break;
                                }
                                index--;
                            }

                            if (index == 0)
                            {
                                result.Add(0);
                                match = true;
                            }
                        }
                        else
                        {
                            result.Add(i);
                            match = true;
                        }

                        break;
                    }

                }
                if (!match)
                {
                    int index = elements.Length;

                    while (index != 0)
                    {
                        if (elements[index - 1] != 0)
                        {
                            result.Add(index);
                            match = true;
                            break;
                        }
                        index--;
                    }

                    if (index == 0)
                    {
                        result.Add(0);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
