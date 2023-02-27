namespace BioscoopSysteemAPI.Services
{
    public class SeatAssignment
    {
        public int AssignRandomSeat(int roomNumber)
        {
            const int frontRows = 2;
            const int backRows = 2;

            // Define the seating layout for the room
            // This scenario plays out the small room 2x10 and 2x15 seats
            var seatingLayout = new List<int[]>();
            for (int i = 0; i < frontRows; i++)
            {
                seatingLayout.Add(new int[10]);
            }
            for (int i = 0; i < backRows; i++)
            {
                seatingLayout.Add(new int[15]);
            }

            // Get the visitor's name
            Console.Write("Enter visitor's name: ");
            string name = Console.ReadLine();

            // Find an unoccupied seat
            int row, seat;
            do
            {
                Random random = new Random();
                row = random.Next(seatingLayout.Count);
                seat = random.Next(seatingLayout[row].Length);
            }
            while (seatingLayout[row][seat] != 0);

            // Reserve the seat
            seatingLayout[row][seat] = 1;

            // Print the reservation details
            Console.WriteLine($"{name}'s seat at row {row + 1} and seat number {seat + 1} has been reserved.");

            // Print the seating chart
            foreach (int[] rowArr in seatingLayout)
            {
                foreach (int seatStatus in rowArr)
                {
                    Console.Write(seatStatus == 1 ? "X" : "O");
                }
                Console.WriteLine();
            }

            // Placeholder return statement, result needs to be filled with the data needed for the visitors ticket.
            return 0;
        }
    }
}
