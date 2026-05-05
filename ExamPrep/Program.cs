/*
10 15 12 18 22 6
12 16 5 6 9 1
 */

namespace RubberDuckDebuggersPt2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> programmerTime = new Queue<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            Stack<int> numTask = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int dartVeidarDucky = 0;
            int thorDucy = 0;
            int bigBlueRubberDucky = 0;
            int smallYellowRubberDucky = 0;

            while (programmerTime.Count>0&&numTask.Count>0)
            {
                int programmerNum = programmerTime.Dequeue();
                int numNumber = numTask.Pop();

                int totalTime = programmerNum * numNumber;

                if (totalTime <= 60)
                {
                    dartVeidarDucky++;
                }
                else if (totalTime > 61 && totalTime <= 120)
                {
                    thorDucy++;
                }
                else if (totalTime > 121 && totalTime <= 180)
                {
                    bigBlueRubberDucky++;
                }
                else if (totalTime > 181 && totalTime <= 240)
                {
                    smallYellowRubberDucky++;
                }
                else if (totalTime > 240)
                {
                    programmerTime.Enqueue(programmerNum);
                    numTask.Push(numNumber - 2);
                }
               
            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {dartVeidarDucky}");
            Console.WriteLine($"Thor Ducky: {thorDucy}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueRubberDucky}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowRubberDucky}");

        }
    }
}
