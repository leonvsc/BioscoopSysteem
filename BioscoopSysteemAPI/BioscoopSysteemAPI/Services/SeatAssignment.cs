namespace BioscoopSysteemAPI.Services
{
    public class SeatAssignment
    {
        // Globals
        /*int[,] Small = new int[10, 10];
        int[,] Medium = new int[12, 10];
        int[,] Large = new int[3, 45];*/

        private string name;
        //private int[,] seating;
        //private int ChosenRoom;



        // testing if I can get this working, only the number of rows are not correct.
        // random Seat also works.
        public int RandomSeat()
        {
            int result = 0;
            int[,] Small = new int[8, 15];
            int[,] Medium = new int[6, 10];
            int[,] Large = new int[2, 10];
            int[,] seating;
            Console.WriteLine("Choose room: ");
            Console.WriteLine("Small = 1: ");
            Console.WriteLine("Medium 2: ");
            Console.WriteLine("Large = 3: ");
            int ChoosenRoom = int.Parse(Console.ReadLine());

            switch (ChoosenRoom)
            {
                case 2:
                    seating = Medium;
                    Console.WriteLine($"This room has {seating.GetLength(0)} rows and {seating.GetLength(1)} seats in each row");
                    break;
                case 3:
                    seating = Large;
                    Console.WriteLine($"This room has {seating.GetLength(0)} rows and {seating.GetLength(1)} seats in each row");
                    break;
                default:
                    seating = Small;
                    Console.WriteLine($"This room has {seating.GetLength(0)} rows and {seating.GetLength(1)} seats in each row");
                    break;
            }

            //testing seating = new int[5, 5; // 10x10 seating arrangement

            Console.Write("Enter the number of visitors: ");
            int numVisitors = int.Parse(Console.ReadLine());
            if (seating.Length < numVisitors)
            {
                Console.WriteLine("Sorry, there is not enough seats for this amount of visitors");
                return 0;
            }

            for (int i = 0; i < numVisitors; i++)
            {
                Console.Write($"Enter visitor {i + 1}'s name: ");
                name = Console.ReadLine();

                int row, seat;
                /* In the do body below, visitors will get a random seat and row assigned.*/
                do
                {
                    Random RandomRow = new Random();
                    Random RandomSeat = new Random();
                    row = RandomRow.Next(seating.GetLength(0));
                    seat = RandomSeat.Next(seating.GetLength(1));

                    if (row > seating.GetLength(0) || seat > seating.GetLength(1))
                    {
                        Console.WriteLine("Sorry, seat or row was out of bounds!");
                        return 0;
                    }

                    if (seating[row, seat] == 1)
                    {
                        Console.WriteLine($"Seat {row + 1}-{seat + 1} is already occupied. Please choose another seat.");
                    }
                }
                /* Hier in de do body kan de bezoeker zelf kiezen 
                 * do
                {
                    Console.Write($"Enter {name}'s preferred row: ");
                    row = int.Parse(Console.ReadLine()) - 1; // substract one to get both dimensions started from zero
                    Console.Write($"Enter {name}'s preferred seat number: ");
                    seat = int.Parse(Console.ReadLine()) - 1;
                    if (seating[row, seat] == 1)
                    {
                        Console.WriteLine($"Seat {row + 1}-{seat + 1} is already occupied. Please choose another seat.");
                    }
                }*/
                while (seating[row, seat] == 1);

                seating[row, seat] = 1; // mark seat as occupied
                Console.WriteLine($"{name}'s seat at row {row + 1} and seat number {seat + 1} has been reserved.");
            }

            // Display seating arrangement
            Console.WriteLine("Seating arrangement:");
            for (int i = 0; i < seating.GetLength(0); i++)
            {
                for (int j = 0; j < seating.GetLength(1); j++)
                {
                    result++;
                    if (seating[i, j] == 1)
                    {
                        Console.Write("X "); // occupied seat
                    }
                    else
                    {
                        Console.Write("O "); // available seat
                    }
                }
                Console.WriteLine(); // start next row of seats
            }
            return result;
        }
    }
