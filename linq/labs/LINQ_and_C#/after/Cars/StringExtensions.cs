using System;
using System.Linq;
using System.Text;

namespace Utility
{
    public static class StringExtensions
    {
        public static string PrettyCase(this string value)
        {
            string[] words = value.Split();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 3)
                {
                    char[] characters = words[i].ToCharArray();
                    for (int j = 1; j < characters.Length; j++)
                    {
                        characters[j] = char.ToLower(characters[j]);
                    }
                    words[i] = new string(characters);
                }
            }

            return String.Join(" ", words);   
        }
    }
}
