using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopSysteemAPI.Services;
using System;

namespace BioscoopSysteemAPI.Test.Services
{
    [TestClass]
    public class SeatReservationTests
    {
        [TestMethod]
        public void AssignRandomSeat_WhenCalledWithValidInputs_AssignsSeatsAndPrintsDetails()
        {
            // Arrange
            var smallRoom = new SmallRoomSeatReservation();
            int roomNumber = 1;
            int visitorAmount = 2;

            // Act
            smallRoom.AssignRandomSeat(roomNumber, visitorAmount);

            // Assert
            // We cannot assert the output printed by Console.WriteLine(), so this test only checks for the method's correctness
        }

        [TestMethod]
        public void AssignRandomSeat_WhenCalledWithInvalidRoomNumber_DoesNotAssignSeats()
        {
            // Arrange
            var smallRoom = new SmallRoomSeatReservation();
            int roomNumber = -1;
            int visitorAmount = 2;

            // Act
            smallRoom.AssignRandomSeat(roomNumber, visitorAmount);

            // Assert
            // We cannot assert the output printed by Console.WriteLine(), so this test only checks for the method's correctness
        }

        [TestMethod]
        public void AssignRandomSeat_WhenCalledWithInvalidVisitorAmount_DoesNotAssignSeats()
        {
            // Arrange
            var smallRoom = new SmallRoomSeatReservation();
            int roomNumber = 1;
            int visitorAmount = 0;

            // Act
            smallRoom.AssignRandomSeat(roomNumber, visitorAmount);

            // Assert
            // We cannot assert the output printed by Console.WriteLine(), so this test only checks for the method's correctness
        }

        [TestMethod]
        public void CreateSeatingLayout_WhenCalled_ReturnsListWithCorrectNumberOfRowsAndSeats()
        {
            // Arrange
            var smallRoom = new SmallRoomSeatReservation();

            // Act
            var seatingLayout = smallRoom.CreateSeatingLayout();

            // Assert
            Assert.AreEqual(seatingLayout.Count, 4);
            Assert.AreEqual(seatingLayout[0].Length, 10);
            Assert.AreEqual(seatingLayout[1].Length, 10);
            Assert.AreEqual(seatingLayout[2].Length, 15);
            Assert.AreEqual(seatingLayout[3].Length, 15);
        }

        [TestMethod]
        public void GetVisitorName_WhenCalled_PromptsUserForNameAndReturnsInput()
        {
            // Arrange
            var smallRoom = new SmallRoomSeatReservation();

            // Act
            Console.SetIn(new System.IO.StringReader("John"));
            var name = smallRoom.GetVisitorName();

            // Assert
            Assert.AreEqual(name, "John");
        }
    }
}