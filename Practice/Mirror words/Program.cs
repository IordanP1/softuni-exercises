using System.Text.RegularExpressions;

namespace Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<sep>[@#])(?<word1>[A-Za-z]{3,})\k<sep>\k<sep>(?<word2>[A-Za-z]{3,})\k<sep>";

            List<string> mirrorWords = new List<string>();
            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }



            foreach (Match match in matches)
            {
                string word1 = match.Groups["word1"].Value;
                string word2 = match.Groups["word2"].Value;
                
                string reverseWords = new string(word2.Reverse().ToArray());
                if (word1 == reverseWords)
                {
                    mirrorWords.Add($"{word1} <=> {word2}");
                }
            }
            if (mirrorWords.Count>0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ",mirrorWords));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
/*@mix#tix3dj#poOl##loOp#wl@@bong&song%4very$long@thong#Part##traP##@@leveL@@Level@##car#rac##tu@pack@@ckap@#rr#sAw##wAs#r#@w1r*/