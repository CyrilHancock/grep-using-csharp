using codecrafters_grep.src.CharacterClass;
using System;
using System.IO;

static bool MatchPattern(string inputLine, string pattern)
{
    if (pattern.Length> 0)
    {
        return CharacterClassImplement.MatchPattern(inputLine, pattern);
    }
    else
    {
        throw new ArgumentException($"Unhandled pattern: {pattern}");
    }
}

if (args[0] != "-E")
{
    Console.WriteLine("Expected first argument to be '-E'");
    Environment.Exit(2);
}

string pattern = args[1];
string inputLine = Console.In.ReadToEnd();

Console.WriteLine("Logs from your program will appear here!");

 
 if (MatchPattern(inputLine, pattern))
 {
    Console.WriteLine("Pattern Exist within the string");
    Environment.Exit(0);
}
 else
 {
    Console.WriteLine("Pattern Does not Exit within the string");
    Environment.Exit(1);
}
