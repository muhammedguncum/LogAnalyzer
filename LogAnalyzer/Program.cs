using System;
using System.IO;
using System.Collections.Generic;

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
        var ipCounts = new Dictionary<string, int>();

        foreach (string line in lines)
        {
            try
            {
                // IP okuma
                string[] parts = line.Split(' ');
                string ip = parts[0];

                // Request (Yol) okuma
                string requestPart = line.Split('"')[1];
                string[] requestParts = requestPart.Split(' ');
                string method = requestParts[0];
                string path = requestParts[1];

                // Status code okuma
                string status = parts[parts.Length - 1];

                Console.WriteLine($"IP: {ip} | PATH: {path} | STATUS: {status}");

                // IP sayma ve gruplama
                if (ipCounts.ContainsKey(ip))
                {
                    ipCounts[ip]++;
                }
                else
                {
                    ipCounts[ip] = 1;
                }
            }
            catch
            {
                Console.WriteLine("Bozuk satır atlandı");
            }
        }

        Console.WriteLine("\n--- IP TRAFFIC ---");
        foreach (var item in ipCounts)
        {
            Console.WriteLine($"{item.Key} → {item.Value} request");
        }

        Console.WriteLine("\nBitti.");
    }
}