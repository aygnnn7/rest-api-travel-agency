using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Entities.Entities;

namespace TravelAgency.DataAcces.Abstract
{
    public interface IHolidayRepository
    {
        Task<long> CreateHolidayAsync(Holiday holiday);
        Task<bool> DeleteHolidayAsync(long holidayId);
        Task<IEnumerable<Holiday>> GetHolidaysAsync();
        Task<IEnumerable<Holiday>> GetHolidaysByFilter(string? location, DateTime startDate, int duration);
        Task<Holiday> GetHolidayByIdAsync(long holidayId);
        Task<bool> UpdateHolidayAsync(Holiday holiday);
    }
}
