using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Entities.Entities;

namespace TravelAgency.DataAcces.Abstract
{
    public interface ILocationRepository
    {
        Task<long> CreateLocationAsync(Location location);
        Task<bool> DeleteLocationAsync(long locationId);
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<Location> GetLocationByIdAsync(long locationId);
        Task<long> UpdateLocationAsync(Location location);

    }

}
