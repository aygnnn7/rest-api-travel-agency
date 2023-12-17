using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Entities.Entities;

namespace TravelAgency.DataAcces.Abstract
{
    public interface IReservationRepository
    {
        Task<long> CreateReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(long reservationId);
        Task<IEnumerable<Reservation>> GetReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(long reservationId);
        Task<bool> UpdateReservationAsync(Reservation reservation);
    }
}
