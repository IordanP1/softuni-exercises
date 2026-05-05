namespace BombHasBeenPlanted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dementions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = dementions[0];
            int cols = dementions[1];

            int ctStartRow = 0;
            int ctStartCol = 0;
            int bombRow = 0;
            int bombCol = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row,col] =='C')
                    {
                        ctStartRow = row;
                        ctStartCol = col;
                    }

                    else if (matrix[row,col]=='B')
                    {
                        bombRow = row;
                        bombCol = col;
                    }
                }
            }
            PlayGame(ctStartRow, ctStartCol, bombRow, bombCol, matrix);
            PrintMatrix(matrix);

        }
        static void PlayGame(int ctRow, int ctCol, int bombRow, int bombCol, char[,] matrix)
        {
            int seconds = 16;
            bool IsDefused = false;
            bool IsDead = false;

            while (seconds > 0) 
            {
                seconds--;
                int prevRow = ctRow;
                int prevCol = ctCol;


                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        ctRow--;
                        break;
                    case "down":
                        ctRow++;
                        break;
                    case "left":
                        ctCol--;
                        break;
                    case "right":
                        ctCol++;
                        break;
                    case "defuse":
                        if (matrix[ctRow,ctCol]=='B')
                        {
                            seconds -= 3;
                            if (seconds >= 0)
                            {
                                matrix[bombRow, bombCol] = 'D';
                                IsDefused = true;
                            }
                        }
                        else
                        {
                            seconds--;
                        }
                            break;
                }
                if (ctRow < 0 || ctRow >= matrix.GetLength(0) || ctCol < 0 || ctCol >= matrix.GetLength(1)) 
                {
                    ctRow = prevRow;
                    ctCol = prevCol;
                        
                }
                if (matrix[ctRow, ctCol] == 'T')
                {
                    matrix[ctRow, ctCol] = '*';
                    IsDead = true;
                }
                if (IsDefused)
                {
                    break;
                }


            }

            if (IsDead)
            {
                Console.WriteLine("Terrorists win!");

            }
            else if (IsDefused)
            {
                Console.WriteLine("Counter-terrorist wins!");
                Console.WriteLine($"Bomb has been defused: {seconds} second/s remaining.");

            }
            else
            {
                if (seconds < 0)
                {
                    matrix[bombRow, bombCol] = 'X';
                }
                Console.WriteLine("Terrorists win!");
                Console.WriteLine("Bomb was not defused successfully!");
                Console.WriteLine($"Time needed: {Math.Abs(seconds)} second/s.");
            }
        }
        static void PrintMatrix(char[,]matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
/*
5, 7
*****T*
****T**
**B****
***T**T
C*****T
up
up
down
right
right
up
up
defuse
down
defuse
 */
/*
2, 10
*TBC*T****
***********
 */