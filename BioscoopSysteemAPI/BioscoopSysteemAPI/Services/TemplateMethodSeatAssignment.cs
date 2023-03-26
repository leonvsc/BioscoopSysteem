using BioscoopSysteemAPI.Dal.Repository;

namespace BioscoopSysteemAPI.Services
{
    public abstract class SeatReservation
    {
        private RoomRepository roomRepository;
        public void AssignRandomSeat(int roomNumber, int visitorAmount)
        {
            if (roomNumber > 0 || roomNumber <= 6 && visitorAmount > 0)
            {
                var seatingLayout = CreateSeatingLayout();

                if (visitorAmount < seatingLayout.Capacity)
                {
                    for (int i = 0; i < visitorAmount; i++)
                    {
                        // Get the visitor's name
                        string name = GetVisitorName();

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
                        PrintReservationDetails(name, row, seat);

                        // Print the seating chart
                        PrintSeatingChart(seatingLayout);
                    }
                }
            }
            // Placeholder return statement, result needs to be filled with the data needed for the visitors ticket. Has to return positions of occupied seats
        }

        public abstract List<int[]> CreateSeatingLayout();

        public abstract string GetVisitorName();

        public virtual void PrintReservationDetails(string name, int row, int seat)
        {
            Console.WriteLine($"{name}'s seat at row {row + 1} and seat number {seat + 1} has been reserved.");
        }

        public virtual void PrintSeatingChart(List<int[]> seatingLayout)
        {
            foreach (int[] rowArr in seatingLayout)
            {
                foreach (int seatStatus in rowArr)
                {
                    Console.Write(seatStatus == 1 ? "X" : "O");
                }
                Console.WriteLine();
            }
        }
    }

    public class SmallRoomSeatReservation : SeatReservation
    {
        public override List<int[]> CreateSeatingLayout()
        {
            Console.WriteLine("This is the small room");
            int frontRows = 2;
            int backRows = 2;

            int totalSeats = (frontRows * 10 + backRows * 15);
            Console.WriteLine($"There are a total of {totalSeats} seats in this room");

            var seatingLayout = new List<int[]>();
            for (int i = 0; i < frontRows; i++)
            {
                seatingLayout.Add(new int[10]);
            }
            for (int i = 0; i < backRows; i++)
            {
                seatingLayout.Add(new int[15]);
            }

            return seatingLayout;
        }

        public override string GetVisitorName()
        {
            Console.Write("Enter visitor's name: ");
            return Console.ReadLine();
        }
    }

    public class MediumRoomSeatReservation : SeatReservation
    {
        public override List<int[]> CreateSeatingLayout()
        {
            Console.WriteLine("This is the medium room");
            int Rows = 6;

            int totalSeats = (Rows * 10);
            Console.WriteLine($"There are a total of {totalSeats} seats in this room");

            var seatingLayout = new List<int[]>();
            for (int i = 0; i < Rows; i++)
            {
                seatingLayout.Add(new int[10]);
            }

            return seatingLayout;
        }

        public override string GetVisitorName()
        {
            Console.Write("Enter visitor's name: ");
            return Console.ReadLine();
        }
    }

    public class LargeRoomSeatReservation : SeatReservation
    {
        public override List<int[]> CreateSeatingLayout()
        {
            Console.WriteLine("This is the large room");
            int Rows = 8;

            int totalSeats = (Rows * 15);
            Console.WriteLine($"There are a total of {totalSeats} seats in this room");

            var seatingLayout = new List<int[]>();
            for (int i = 0; i < Rows; i++)
            {
                seatingLayout.Add(new int[15]);
            }

            return seatingLayout;
        }

        public override string GetVisitorName()
        {
            Console.Write("Enter visitor's name: ");
            return Console.ReadLine();
        }
    }
}
