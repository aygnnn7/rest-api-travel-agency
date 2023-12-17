using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business.DTOs.Holiday;

namespace TravelAgency.DataAcces.DTOs.Reservation
{
    public class ResponseReservationDTO
    {
        public long? Id { get; set; }
        public string? ContactName { get; set; }
        public string? PhoneNumber { get; set; }
        public ResponseHolidayDTO Holiday { get; set; }
    }
}
