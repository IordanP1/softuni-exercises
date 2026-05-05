namespace Escape_the_Maze_Pt2
{
    internal class Program
    {
        const char startingPosition = 'P';
        const char Exit = 'X';
        const char Monster = 'M';
        const char Heal = 'H';
        const char Coridor = '-';

        static void Main(string[] args)
        {

            Dictionary<string, int[]> movements = new Dictionary<string, int[]>()
            {
                ["up"] = [-1, 0],
                ["down"] = [1,0],
                ["left"] = [0,-1],
                ["right"] = [0,1],
            };
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n,n];
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                }
               
            }
            int playerRow = -1;
            int playerCol = -1;
            bool isFound = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j]==startingPosition)
                    {
                        playerRow = i;
                        playerCol = j;
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            int healt = 100;
            bool exitReached = false;
            while (healt > 0 && !exitReached) 
            { 
                string command = Console.ReadLine();
                int[] change = movements[command];

                int newRow = playerRow + change[0];
                int newCol = playerCol + change[1];

                if (newRow < 0 || newRow >= n || newCol < 0 || newCol >= n)
                {
                    continue;
                }

                if (matrix[newRow,newCol]==Monster)
                {
                    healt = Math.Max(healt - 40, 0);
                }
                if (matrix[newRow,newCol]==Heal)
                {
                    healt = Math.Min(healt + 15, 100);
                }
                if (matrix[newRow,newCol]==Exit)
                {
                    exitReached = true;
                }

                matrix[playerRow, playerCol] = Coridor;
                playerRow = newRow;
                playerCol = newCol;
                matrix[playerRow, playerCol] = startingPosition;


            }
            if (exitReached)
            {
                Console.WriteLine("Player escaped the maze. Danger passed!");
            }
            else
            {
                Console.WriteLine("Player is dead. Maze over!");
            }
            Console.WriteLine($"Player's health: {healt} units");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
/*
5
-----
-PM--
-M---
---H-
-X---
down
right
down
down
left
 */