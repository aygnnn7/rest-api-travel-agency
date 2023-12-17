using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAcces.DTOs.Reservation;

namespace TravelAgency.Business.Abstract
{
    public interface IReservationService
    {
        Task<ResponseReservationDTO> CreateReservationAsync(CreateReservationDTO reservationDto);
        Task<bool> DeleteReservationAsync(int reservationId);
        Task<IEnumerable<ResponseReservationDTO>> GetReservationsAsync();
        Task<ResponseReservationDTO> GetReservationByIdAsync(int reservationId);
        Task<ResponseReservationDTO> UpdateReservationAsync(UpdateReservationDTO reservationDto);
    }
}
