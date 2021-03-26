using System;
using System.Collections.Generic;
using System.Text;

public static class Helper
{
    public static string GetProperty(string name)
    {
        List<int> capitalLettersInexes = GetCapitalLettersInexes(name);
        string result = "";
        for (int i = 0; i < capitalLettersInexes.Count - 1; i++)
        {
            int start = capitalLettersInexes[i];
            int length = capitalLettersInexes[i + 1] - start;

            result += name.Substring(capitalLettersInexes[i], length);
            result += " ";

            if (i + 1 == capitalLettersInexes.Count - 1)
            {
                result += name.Substring(capitalLettersInexes[i + 1]);
            }
        }
        return result;
    }
    private static List<int> GetCapitalLettersInexes(string name)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < name.Length; i++)
        {
            if (name[i] >= 'A' && name[i] <= 'Z')
            {
                indexes.Add(i);
            }
        }
        return indexes;
    }
}

