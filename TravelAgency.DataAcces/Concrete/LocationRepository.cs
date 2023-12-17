using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAcces.Abstract;
using TravelAgency.Entities.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TravelAgency.DataAcces.Concrete
{
    public class LocationRepository : ILocationRepository
    {
        

        public async Task<long> CreateLocationAsync(Location location)
        {
            if (location.ImageUrl == null) location.ImageUrl = "dummyurl";
            using (AgencyDbContext db = new AgencyDbContext())
            {

                db.Locations.Add(location);
                await db.SaveChangesAsync();
            }
            return location.Id;
                
        }

        public async Task<bool> DeleteLocationAsync(long locationId)
        {
            var location = await GetLocationByIdAsync(locationId);
            if (location != null)
            {
                using (AgencyDbContext db = new AgencyDbContext())
                {
                    db.Locations.Remove(location);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            using (AgencyDbContext db = new AgencyDbContext())
            {
                return await db.Locations.ToListAsync();
            }
           
                
        }

        public async Task<Location> GetLocationByIdAsync(long locationId)
        {
            using (AgencyDbContext db = new AgencyDbContext())
            {
                return await db.Locations.FindAsync(locationId);
            }
        }

        public async Task<long> UpdateLocationAsync(Location location)
        {
            if (location.ImageUrl == null) location.ImageUrl = "dummyurl";
            using (AgencyDbContext db = new AgencyDbContext())
            {
                db.Locations.Entry(location).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return location.Id;

        }
    }
}
