using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "server_logs.txt";
        Console.WriteLine("Program başladı...\n");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Log file not found!");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        Console.WriteLine($"{lines.Length} satır başarıyla okundu.");
    }
}