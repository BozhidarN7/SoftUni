using System;
using System.Collections.Generic;

namespace _4.MorseCodeTranslator
{
    class MorseCodeTranslator
    {
        private static Dictionary<string, string> morseCodeTable = new Dictionary<string, string>()
        {
            {".-" , "A"},
            {"-..." , "B"},
            {"-.-." , "C"},
            {"-.." , "D"},
            {"." , "E"},
            {"..-." , "F"},
            {"--." , "G"},
            {"...." , "H"},
            {".." , "I"},
            {".---" , "J"},
            {"-.-" , "K"},
            {".-.." , "L"},
            {"--" , "M"},
            {"-." , "N"},
            {"---" , "O"},
            {".--." , "P"},
            {"--.-" , "Q"},
            {".-." , "R"},
            {"..." , "S"},
            {"-" , "T"},
            {"..-" , "U"},
            {"...-" , "V"},
            {".--" , "W"},
            {"-..-" , "X"},
            {"-.--" , "Y"},
            {"--.." , "Z"},
        };
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string[] letter = code.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string result = "";
            for (int i = 0; i < letter.Length; i++)
            {
                if (letter[i] == "|")
                {
                    result += " ";
                    continue;
                }
                string current = "";
                for (int j = 0; j < letter[i].Length; j++)
                {
                    current += letter[i][j];
                }
                result += morseCodeTable[current];
            }
            Console.WriteLine(result);
        }
    }
}
