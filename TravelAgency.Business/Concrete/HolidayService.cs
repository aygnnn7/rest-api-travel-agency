using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business.Abstract;
using TravelAgency.Business.DTOs.Holiday;
using TravelAgency.DataAcces.Abstract;
using TravelAgency.DataAcces.DTOs.Location;
using TravelAgency.Entities.Entities;

namespace TravelAgency.Business.Concrete
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public HolidayService(IHolidayRepository holidayRepository, ILocationRepository locationRepository, IMapper mapper)
        {
            _holidayRepository = holidayRepository;
            _locationRepository = locationRepository;   
            _mapper = mapper;
        }

        public async Task<ResponseHolidayDTO> CreateHolidayAsync(CreateHolidayDTO holidayDto)
        {
            
            Holiday holiday = _mapper.Map<Holiday>(holidayDto);

            holiday.LocationId = holidayDto.Location;
            holiday.Id = await _holidayRepository.CreateHolidayAsync(holiday);
            ResponseHolidayDTO response = _mapper.Map<ResponseHolidayDTO>(holiday);
            return response;
        }

        public async Task<bool> DeleteHolidayAsync(int holidayId)
        {
            return await _holidayRepository.DeleteHolidayAsync(holidayId);
        }

        public async Task<ResponseHolidayDTO> GetHolidayByIdAsync(int holidayId)
        {
            Holiday holiday = await _holidayRepository.GetHolidayByIdAsync(holidayId);
            holiday.Location = await _locationRepository.GetLocationByIdAsync((long)holiday.LocationId);
            return _mapper.Map<ResponseHolidayDTO>(holiday);
        }

        public async Task<IEnumerable<ResponseHolidayDTO>> GetHolidaysAsync()
        {
            List<Holiday> holidays = (await _holidayRepository.GetHolidaysAsync()).ToList();
            
            for (int i = 0; i < holidays.Count(); i++)
            {
                holidays[i  ].Location = await _locationRepository.GetLocationByIdAsync((long)holidays[i].LocationId);
            }

            return _mapper.Map<List<ResponseHolidayDTO>>(holidays);
        }
         
        public async Task<IEnumerable<ResponseHolidayDTO>> GetHolidaysByFilter(string? location, DateTime startDate, int duration)
        {
            IEnumerable<ResponseHolidayDTO> responses = _mapper.Map<IEnumerable<ResponseHolidayDTO>>(await _holidayRepository.GetHolidaysByFilter(location, startDate, duration));
            return responses;
        }

        public async Task<ResponseHolidayDTO> UpdateHolidayAsync(UpdateHolidayDTO holidayDto)
        {
            Holiday holiday = _mapper.Map<Holiday>(holidayDto);
            holiday.LocationId = holidayDto.Location;
            _holidayRepository.UpdateHolidayAsync(holiday);

            ResponseHolidayDTO response = _mapper.Map<ResponseHolidayDTO>(holidayDto);
            Location location = await _locationRepository.GetLocationByIdAsync(holidayDto.Location);
            response.Location = _mapper.Map<ResponseLocationDTO>(location);
            return response;
        }

    }
}
