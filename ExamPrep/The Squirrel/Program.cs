namespace The_Squirrel
{
    internal class Program
    {
        const char Squirrel = 's';
        const char Hazelnut = 'h';
        const char Empty = '*';
        const char Trap = 't';

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            char[,] matrix = new char[n,n];

            
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            int SquirelRow = -1;
            int squirelCol = -1;



            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == Squirrel)
                    {
                        SquirelRow = i;
                        squirelCol = j;
        
                        break;
                    }
                }
            }

            int hazelnutCount = 0;
            bool Exited = false;
            //left, right, up, down //moga da gi vzema s Queue zashtoto vzima purviq i go maha i chete natam
            int commandIndex = 0;
            while (hazelnutCount < 3 && !Exited && commands.Count > 0) 
            {
                string command = commands.Dequeue();
               


                int newRow = SquirelRow;
                int newCol = squirelCol;


                if (command == "left")
                {
                    newCol--;
                }
                else if (command == "right")
                {
                    newCol++;
                }
                else if (command == "up")
                {
                    newRow--;
                }
                else if (command == "down")
                {
                    newRow++;
                }

                if (newRow < 0 || newRow >= n || newCol < 0 || newCol >= n) 
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    Exited = true;
                    break;
                }

                char nextCell = matrix[newRow, newCol];
                if (nextCell==Trap)
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Exited=true;
                    break;
                }

                if (nextCell==Hazelnut)
                {
                    hazelnutCount++;
                    matrix[newRow, newCol] = Empty;
                }

                if (hazelnutCount == 3) 
                {
                    Console.WriteLine("Good job! You have collected all hazelnuts!");
                    break;
                }

                matrix[SquirelRow, squirelCol] = Empty;
                SquirelRow = newRow;
                squirelCol = newCol;
                matrix[SquirelRow, squirelCol] = Squirrel;
            }
            if (!Exited && hazelnutCount < 3) 
            {
                Console.WriteLine("There are more hazelnuts to collect.");

            }
            Console.WriteLine($"Hazelnuts collected: {hazelnutCount}");
           
        }
    }
}
/*
5
left, left, up, right, up, up
**h**
t****
*h***
*h*s*
*****
 */