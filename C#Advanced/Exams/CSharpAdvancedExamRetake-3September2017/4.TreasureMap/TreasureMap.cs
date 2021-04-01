using System;
using System.Collections.Generic;

namespace _4.TreasureMap
{
    class TreasureMap
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <  n; i++)
            {
                string input = Console.ReadLine();
                int hashTagIndex = input.IndexOf('#');
                int exclamationMarkIndex = input.IndexOf('!');

                List<string> validMatches = new List<string>();

                if (hashTagIndex < exclamationMarkIndex)
                {
                    string current = input.Substring(hashTagIndex + 1, exclamationMarkIndex - hashTagIndex -1);
                    input = input.Remove(hashTagIndex, exclamationMarkIndex - hashTagIndex + 1);
                    validMatches.Add(current);
                }
                else
                {
                    string current = input.Substring(exclamationMarkIndex + 1, hashTagIndex - exclamationMarkIndex - 1);
                    input = input.Remove(exclamationMarkIndex, hashTagIndex - exclamationMarkIndex + 1);
                    validMatches.Add(current);
                }
            }
        }
    }
}
