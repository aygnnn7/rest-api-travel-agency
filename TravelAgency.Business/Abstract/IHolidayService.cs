using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business.DTOs.Holiday;

namespace TravelAgency.Business.Abstract
{
    public interface IHolidayService
    {
        Task<ResponseHolidayDTO> CreateHolidayAsync(CreateHolidayDTO holidayDto);
        Task<bool> DeleteHolidayAsync(int holidayId);
        Task<IEnumerable<ResponseHolidayDTO>> GetHolidaysAsync();
        Task<ResponseHolidayDTO> GetHolidayByIdAsync(int holidayId);
        Task<ResponseHolidayDTO> UpdateHolidayAsync(UpdateHolidayDTO holidayDto);
        Task<IEnumerable<ResponseHolidayDTO>> GetHolidaysByFilter(string? location, DateTime startDate, int duration);
       
    }
}
