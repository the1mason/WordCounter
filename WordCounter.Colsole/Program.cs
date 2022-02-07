using Microsoft.Extensions.Logging;
using System;
using WordCounter.Lib;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Enter path to file or url:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string path = Console.ReadLine();
        Console.ResetColor();
        
    }

    internal static void PrintError(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    internal static void PrintSuccess(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}

