namespace Fortress
{
    internal class Program
    {
        const char Spy = 'S';
        const char Exit = 'E';
        const char Guard = 'G';
        const char BlindSpot = 'B';
        const char Empty = '.';
        static void Main(string[] args)
        {

            Dictionary<string, int[]> movements = new Dictionary<string, int[]>()
            {
                ["up"] = [-1,0],
                ["down"] = [1, 0],
                ["left"] = [0, -1],
                ["right"] = [0, 1],


            };
            int n = int.Parse(Console.ReadLine());

            char[,]matrix = new char[n,n];

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
                    if (matrix[i,j]==Spy)
                    {
                        playerRow = i;
                        playerCol = j;
                        isFound = true;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }

            int stealth = 100;
            bool exitReached = false;
            while (stealth > 0 && !exitReached) 
            {
                string command = Console.ReadLine();

                int[] chanege = movements[command];
                int nextRow = playerRow + chanege[0];
                int nextCol = playerCol + chanege[1];

                if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= n)
                {
                    continue;
                }


                if (matrix[nextRow,nextCol]==Guard)
                {
                    stealth -= 40;
                    if (stealth>0)
                    {
                        matrix[nextRow, nextCol] = Empty;
                    }
                    if (stealth<0)
                    {
                        matrix[nextRow, nextCol] = Spy;
                    }
                }
                if (matrix[nextRow,nextCol]==BlindSpot)
                {
                    stealth = Math.Min(stealth + 15, 100);
                }
                if (matrix[nextRow,nextCol]==Exit)
                {
                    exitReached = true;
                    //matrix[nextRow, nextCol] = Exit;
                }
                matrix[playerRow, playerCol] = Empty;
                playerRow = nextRow;
                playerCol = nextCol;
                //matrix[playerRow, playerCol] = Spy;

               
            }
            if (stealth <= 0)
            {
                Console.WriteLine("Mission failed. Spy compromised.");
            }
            if (exitReached)
            {
                Console.WriteLine("Mission accomplished. Spy extracted successfully.");
            }
            Console.WriteLine($"Stealth level: {stealth} units");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }


        }
    }
}
/*
 5
...G.
.SG..
.G...
..GB.
.E.B.
down
right
down
down
left
 */