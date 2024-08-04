using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace codecrafters_grep.src.CharacterClass
{
    internal class CharacterClassImplement
    {
        public static bool MatchPattern(string inputLine, string pattern)
        {
            switch (pattern)
            {
                case "\\d":
                    return inputLine.Any(char.IsDigit);

                case "\\w":
                    return inputLine.All(char.IsLetterOrDigit);

                case string s when s.StartsWith("[^") && s.EndsWith("]"):
                    var negatedCharacters = s.Substring(2, s.Length - 3);
                    return !inputLine.Any(negatedCharacters.Contains);

                case string s when s.StartsWith("[") && s.EndsWith("]"):
                    var characters = s.Substring(1, s.Length - 2);
                    return inputLine.Any(characters.Contains);
                default:
                    return Regex.IsMatch(inputLine, pattern);
            }
        }
    }
}
