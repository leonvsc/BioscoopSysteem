using BioscoopSysteemAPI.Dal.Repository;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioscoopSysteemAPI.Tests.Services
{
    [TestClass]
    public class EmptySeatsForSelectionTests
    {
        private Mock<ISeatRepository> _mockSeatRepository;
        private EmptySeatsForSelection _emptySeatsForSelection;

        [TestInitialize]
        public void Initialize()
        {
            _mockSeatRepository = new Mock<ISeatRepository>();
            _emptySeatsForSelection = new EmptySeatsForSelection(_mockSeatRepository.Object);
        }

        [TestMethod]
        public async Task GetEmptySeatsForSelection_ShouldReturnEmptySeats()
        {
            // Arrange
            var emptySeats = new List<Seat>()
            {
                new Seat { SeatId = 1, SeatRow = 1, SeatNumber = 1 },
                new Seat { SeatId = 2, SeatRow = 2, SeatNumber = 2 }
            };

            _mockSeatRepository.Setup(r => r.GetEmptySeatsForSelectionAsync()).ReturnsAsync(emptySeats);

            // Act
            var result = await _emptySeatsForSelection.GetEmptySeatsForSelection();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.ElementAt(0).SeatRow);
            Assert.AreEqual(1, result.ElementAt(0).SeatNumber);
            Assert.AreEqual(2, result.ElementAt(1).SeatRow);
            Assert.AreEqual(2, result.ElementAt(1).SeatNumber);
        }
    }
}
