namespace EvenLines
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        private static char[] CharToReplace = new char[] { '-', ',', '.', '!', '?' };
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var streamReader = new StreamReader(inputFilePath);

            bool isEvenLine = true;
            StringBuilder stringBuilder = new StringBuilder();
            while (!streamReader.EndOfStream)
            {
                string line = Console.ReadLine();

                if (isEvenLine)
                {
                   stringBuilder.AppendLine(ReplaceChars(line));
                }
                isEvenLine = !isEvenLine;

            }
            return stringBuilder.ToString();
        }
        private static string ReplaceChars(string line)
        {
            string[] words = line.Split();
            Array.Reverse(words);

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < CharToReplace.Length; j++)
                {
                    words[i] = words[i].Replace(CharToReplace[j], '@'); 
                }
            }
            return string.Join(" ", words);
        }
    }
}
