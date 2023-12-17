﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAcces.DTOs.Location
{
    public class CreateLocationDTO
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string? ImageUrl { get; set; }
    }
}
