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

        foreach (string line in lines)
        {
            try
            {
                string[] parts = line.Split(' ');
                string ip = parts[0];

                string requestPart = line.Split('"')[1];
                string[] requestParts = requestPart.Split(' ');

                string method = requestParts[0];
                string path = requestParts[1];

                string status = parts[parts.Length - 1];

                Console.WriteLine($"IP: {ip} | PATH: {path} | STATUS: {status}");
            }
            catch
            {
                Console.WriteLine("Bozuk satır atlandı");
            }
        }
    }
}