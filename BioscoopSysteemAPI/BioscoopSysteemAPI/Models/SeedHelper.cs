namespace BioscoopSysteemAPI.Models
{
    public class SeedHelper
    {
        public static IEnumerable<Movie> GetMovieSeeds()
        {
            var movie = new List<Movie>()
            {
                new Movie()
                {
                MovieId = 1,
                Name = "ScaryMovie",
                Date= DateTime.Now,
                Add3DMovie = true,
                Description = "Lorem ipsum dolor sit amet",
                Price = 12,
                AllowedAge = 16,
                ImageUrl = "/Images/Movies/Movie1.jpeg"

                },

                new Movie(){
                MovieId = 2,
                Name = "AntMan",
                Date = DateTime.Now,
                Add3DMovie = false,
                Description = "Lorem ipsum dolor sit amet",
                Price = 9,
                AllowedAge = 8,
                ImageUrl = "/Images/Movies/Movie2.jpeg"
                },

                new Movie()
                {
                MovieId = 3,
                Name = "Plane",
                Date= DateTime.Now,
                Add3DMovie = true,
                Description = "Lorem ipsum dolor sit amet",
                Price = 12,
                AllowedAge = 12,
                ImageUrl = "/Images/Movies/Movie3.jpeg"
                }


            };

            return movie;
        }

        public static IEnumerable<MovieRoom> GetMovieRoomSeeds()
        {
            var movieRoom = new List<MovieRoom>() {

            new MovieRoom()
            {
                MovieId = 1,
                RoomId = 2,

            },

            new MovieRoom()
            {
                MovieId = 2,
                RoomId = 3,

            },

            new MovieRoom()
            {
                MovieId = 3,
                RoomId = 1,

            }

            };

            return movieRoom;

        }

        public static IEnumerable<Payment> GetPaymentSeeds()
        {
            var payment = new List<Payment>()
            {
                new Payment()
                {
                PaymentId = 1,
                MollieId = "tr_9x5yAUbWZ2",
                PaidAt = DateTime.Now,
                Amount = 24,
                PaymentMethod = "Ideal",
                PaymentStatus = "paid",
                ReservationId = 1
                },

                new Payment()
                {
                PaymentId = 2,
                MollieId = "tr_9x5yAUbWZ2",
                PaidAt = DateTime.Now,
                Amount = 12,
                PaymentMethod = "CreditCard",
                PaymentStatus = "paid",
                ReservationId = 2

                },

                new Payment()
                {
                PaymentId = 3,
                MollieId = "tr_9x5yAUbWZ2",
                PaidAt = DateTime.Now,
                Amount = 12,
                PaymentMethod = "CreditCard",
                PaymentStatus = "paid",
                ReservationId = 3
                }


            };

            return payment;
        }

        public static IEnumerable<Reservation> GetReservationSeeds()
        {
            var reservation = new List<Reservation>()
            {
                new Reservation()
                {
                ReservationId = 1,
                DateTime = DateTime.Now,
                Location = "Amsterdam",
                TicketAmount = 1,
                Age = "12 tm 65",
                TotalPrice = 12.00,
                IsStudent = false,
                WantsPopcorn = false,
                WantsVIP = false,
                WantsKinderfeestje = false,
                SeatId = 6,
                MovieId = 1,
                VisitorId = 1
                },

                new Reservation()
                {
                ReservationId = 2,
                DateTime = DateTime.Now,
                Location = "Haarlem",
                TicketAmount = 1,
                Age = "65+",
                TotalPrice = 12.00,
                IsStudent = false,
                WantsPopcorn = false,
                WantsVIP = false,
                WantsKinderfeestje = false,
                SeatId = 5,
                MovieId = 2,
                VisitorId = 2

                },

                new Reservation()
                {
                ReservationId = 3,
                DateTime = DateTime.Now,
                Location = "Zaandam",
                TicketAmount = 1,
                Age = "12 tm 65",
                TotalPrice = 9.00,
                IsStudent = true,
                WantsPopcorn = false,
                WantsVIP = false,
                WantsKinderfeestje = false,
                SeatId = 4,
                MovieId = 3,
                VisitorId = 3
                }

            };

            return reservation;
        }

        public static IEnumerable<Room> GetRoomSeeds()
        {
            var room = new List<Room>()
            {
                new Room()
                {
                RoomId = 1,
                InUse = false,
                NumberOfSeatsAvailable = 150
                },

                new Room()
                {
                RoomId = 2,
                InUse = false,
                NumberOfSeatsAvailable = 250

                },

                new Room()
                {
                RoomId = 3,
                InUse = false,
                NumberOfSeatsAvailable = 75
                }

            };

            return room;
        }

        public static IEnumerable<Seat> GetSeatSeeds()
        {
            var room = new List<Seat>()
            {
                new Seat()
                {
                SeatId = 1,
                SeatNumber = 8,
                SeatRow = 3,
                MovieId = 1
                },

                new Seat()
                {
                SeatId = 2,
                SeatNumber = 14,
                SeatRow = 2,
                MovieId = 2

                },

                new Seat()
                {
                SeatId = 3,
                SeatNumber = 16,
                SeatRow = 1,
                MovieId = 3
                }

            };

            return room;
        }

        public static IEnumerable<Ticket> GetTicketSeeds()
        {
            var ticket = new List<Ticket>()
            {
                new Ticket()
                {
                TicketId = 1,
                DateTime = DateTime.Now,
                MovieName = "ScaryMovie",
                Quantity = 2,
                SeatId = 1,
                VisitorId = 2,
                RoomId = 2,
                PaymentId = 1
                },

                new Ticket()
                {
                TicketId = 2,
                DateTime = DateTime.Now,
                MovieName = "AntMan",
                Quantity = 1,
                SeatId = 3,
                VisitorId = 3,
                RoomId = 3,
                PaymentId = 2
                },

                new Ticket()
                {
                TicketId = 3,
                DateTime = DateTime.Now,
                MovieName = "Plane",
                Quantity = 1,
                SeatId = 2,
                VisitorId = 1,
                RoomId = 1,
                PaymentId = 3
                }

            };

            return ticket;
        }

        public static IEnumerable<Visitor> GetVisitorSeeds()
        {
            var visitor = new List<Visitor>()
            {
                new Visitor()
                {
                VisitorId = 1,
                FirstName = "Piet",
                LastName = "Avans",
                Age = 25
                },

                new Visitor()
                {
                VisitorId = 2,
                FirstName = "Jan",
                LastName = "School",
                Age = 28
                },

                new Visitor()
                {

                VisitorId = 3,
                FirstName = "Hans",
                LastName = "Koning",
                Age = 19
                }

            };

            return visitor;
        }
    }
}
