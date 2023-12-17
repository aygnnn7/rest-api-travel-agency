using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAcces.DTOs.Location;

namespace TravelAgency.Business.DTOs.Holiday
{
    public class ResponseHolidayDTO
    {
        public long? Id { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; } 
        public int? Duration { get; set; }
        public double? Price { get; set; }
        public int? FreeSlots { get; set; }

        public ResponseLocationDTO Location { get; set; }
    }
}
