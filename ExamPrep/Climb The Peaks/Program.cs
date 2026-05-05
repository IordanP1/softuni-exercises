namespace ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> peaksDificulties = new Dictionary<string, int>()
            {
                {"Vihren",80},
                {"Kutelo",90 },
                {"Banski Suhodol",100},
                {"Polezhan",60 },
                {"Kamenitza",70 }
            };
            Queue<string> peaks = new(peaksDificulties.Keys);
            List<string> concoredPeaks = new List<string>();

            Stack<int> foodPortions =new(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            Queue<int> staminaQuantities = new(Console.ReadLine()
               .Split(", ")
               .Select(int.Parse));

            while (foodPortions.Any() && staminaQuantities.Any() && peaks.Any()) 
            {
                int foodPortion = foodPortions.Pop();//posleden
                int staminaQuantity = staminaQuantities.Dequeue();//purvi

                string peakName = peaks.Peek();
                int peakDifficulty = peaksDificulties[peakName];

                if (foodPortion+ staminaQuantity>=peakDifficulty)
                {
                    concoredPeaks.Add(peaks.Dequeue());
                }
            }
            if (!peaks.Any())
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (concoredPeaks.Any())
            {
                Console.WriteLine($"Conquered peaks:");
                foreach (var peak in concoredPeaks)
                {
                    Console.WriteLine(peak);
                }
            }
        }
    }
}
/*
10, 20, 34, 26, 12, 10, 45
30, 28, 17, 17, 13, 10, 10
 */
