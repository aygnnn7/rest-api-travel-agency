using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business.Abstract;
using TravelAgency.Business.DTOs.Holiday;
using TravelAgency.DataAcces.Abstract;
using TravelAgency.DataAcces.DTOs.Location;
using TravelAgency.DataAcces.DTOs.Reservation;
using TravelAgency.Entities.Entities;

namespace TravelAgency.Business.Concrete
{
    public class ReservationService : IReservationService
    {
        
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly IHolidayService _holidayService;
        public ReservationService(
                            IReservationRepository reservationRepository, IHolidayService holidayService,
                            IMapper mapper)
        {
            _holidayService = holidayService;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ResponseReservationDTO> CreateReservationAsync(CreateReservationDTO reservationDto)
        {
            Reservation reservation = _mapper.Map<Reservation>(reservationDto);
            reservation.HolidayId = reservationDto.Holiday;

            reservation.Id = await _reservationRepository.CreateReservationAsync(reservation);
            ResponseReservationDTO response = _mapper.Map<ResponseReservationDTO>(reservation);
            return response;
        }

        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            return await _reservationRepository.DeleteReservationAsync(reservationId);
        }

        public async Task<ResponseReservationDTO> GetReservationByIdAsync(int reservationId)
        {
            Reservation reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);
            ResponseReservationDTO response = _mapper.Map<ResponseReservationDTO>(reservation);
            response.Holiday = await _holidayService.GetHolidayByIdAsync((int)reservation.HolidayId);
            return response;
        }

        public async Task<IEnumerable<ResponseReservationDTO>> GetReservationsAsync()
        {
            List<Reservation> reservations = (await _reservationRepository.GetReservationsAsync()).ToList();
            List<ResponseReservationDTO> responseReservations = _mapper.Map<List<ResponseReservationDTO>>(reservations);

            for (int i = 0; i < responseReservations.Count(); i++)
            {
                responseReservations[i].Holiday = await _holidayService.GetHolidayByIdAsync((int)reservations[i].HolidayId);
            }
            return responseReservations;
        }

        public async Task<ResponseReservationDTO> UpdateReservationAsync(UpdateReservationDTO reservationDto)
        {
            Reservation reservation = _mapper.Map<Reservation>(reservationDto);
            reservation.HolidayId = reservationDto.Holiday;
            _reservationRepository.UpdateReservationAsync(reservation);

            ResponseReservationDTO response = _mapper.Map<ResponseReservationDTO>(reservation);
            response.Holiday = await _holidayService.GetHolidayByIdAsync((int)reservationDto.Holiday);
            return response;
        }
    }
}
