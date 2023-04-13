using System.Text.RegularExpressions;

namespace Practice.Core;

public class StringHelper
{
    public static string ReverseString(string inputString)
    {
        var arrayLine = inputString.ToArray();
        Array.Reverse(arrayLine);
        return new string(arrayLine);
    }

    public static string FindLongestVowelSubstring(string inputString)
    {
        var longestSubstring = string.Empty;

        for (var i = 0; i < inputString.Length; i++)
        {
            if (!IsVowel(inputString[i])) continue;
            for (var j = inputString.Length - 1; j > i; j--)
            {
                if (!IsVowel(inputString[j])) continue;
                var substring = inputString.Substring(i, j - i + 1);
                if (substring.Length > longestSubstring.Length)
                {
                    longestSubstring = substring;
                }

                break;
            }
        }

        return longestSubstring;
    }

    private static bool IsVowel(char c)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        return vowels.Contains(char.ToLower(c));
    }

    public static bool ValidateString(string input, out string invalidChars)
    {
        invalidChars = Regex.Replace(input, @"[a-z]+", "");
        return Regex.IsMatch(input, @"^[a-z]*$");
    }

    public static Dictionary<char, int> CountRepeatedCharacters(string inputString)
    {
        var characterCount = new Dictionary<char, int>();

        foreach (var c in inputString)
        {
            if (characterCount.ContainsKey(c))
            {
                characterCount[c]++;
            }
            else
            {
                characterCount.Add(c, 1);
            }
        }

        return characterCount;
    }
}