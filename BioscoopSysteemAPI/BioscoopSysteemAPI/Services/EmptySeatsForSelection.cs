using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;

namespace BioscoopSysteemAPI.Services
{
    public class EmptySeatsForSelection
    {
        private readonly ISeatRepository _seatRepository;

        public EmptySeatsForSelection (ISeatRepository seatRepository)
        {
            _seatRepository= seatRepository;
        }

        public async Task<IEnumerable<Seat>> GetEmptySeatsForSelection()
        {
            var seats = await _seatRepository.GetEmptySeatsForSelectionAsync();
            
            return seats;
            
        }
            
    }
}
