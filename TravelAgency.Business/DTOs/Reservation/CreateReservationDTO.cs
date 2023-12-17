using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAcces.DTOs.Reservation
{
    public class CreateReservationDTO
    {
        public string? ContactName { get; set; }
        public string? PhoneNumber { get; set; }
        public long? Holiday { get; set; }
    }
}
