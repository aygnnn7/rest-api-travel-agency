using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business.Abstract;
using TravelAgency.DataAcces.Abstract;
using TravelAgency.DataAcces.Concrete;
using TravelAgency.DataAcces.DTOs.Location;
using TravelAgency.Entities.Entities;

namespace TravelAgency.Business.Concrete
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<ResponseLocationDTO> CreateLocationAsync(CreateLocationDTO locationDto)
        {
            Location location = _mapper.Map<Location>(locationDto);
            location.Id = await _locationRepository.CreateLocationAsync(location);
            ResponseLocationDTO response = _mapper.Map<ResponseLocationDTO>(location);
            return response;
          
        }

        public async Task<bool> DeleteLocationAsync(long locationId)
        {
            return await _locationRepository.DeleteLocationAsync(locationId);
        }

        public async Task<IEnumerable<ResponseLocationDTO>> GetLocationsAsync()
        {
            var locations = await _locationRepository.GetLocationsAsync();

            return _mapper.Map<List<ResponseLocationDTO>>(locations);
        }

        public async Task<ResponseLocationDTO> GetLocationByIdAsync(long locationId)
        {
            Location location = await _locationRepository.GetLocationByIdAsync(locationId);
            return _mapper.Map<ResponseLocationDTO>(location);
        }

        public async Task<ResponseLocationDTO> UpdateLocationAsync(UpdateLocationDTO locationDto)
        {
            Location location = _mapper.Map<Location>(locationDto);
            _locationRepository.UpdateLocationAsync(location);
            return _mapper.Map<ResponseLocationDTO>(locationDto);
        }

    }
}
