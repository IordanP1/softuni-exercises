using System;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<symbol>[$%])(?<tag>[A-Z][a-z]{2,})\k<symbol>: \[(?<one>\d+)\]\|\[(?<two>\d+)\]\|\[(?<three>\d+)\]\|$";

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string tag = match.Groups["tag"].Value;

                    int num1 = int.Parse(match.Groups["one"].Value);
                    int num2 = int.Parse(match.Groups["two"].Value);
                    int num3 = int.Parse(match.Groups["three"].Value);

                    string decrypted = $"{(char)num1}{(char)num2}{(char)num3}";

                    Console.WriteLine($"{tag}: {decrypted}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
