using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Entities.Entities;

namespace TravelAgency.Business.DTOs.Holiday
{
    public class CreateHolidayDTO
    {
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Duration { get; set; }
        public string Price { get; set; }
        public int? FreeSlots { get; set; }

        public int Location { get; set; }
    }
}
