using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business.DTOs.Holiday;
using TravelAgency.DataAcces.DTOs.Location;
using TravelAgency.Entities.Entities;

namespace TravelAgency.Business.AutoMappers
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, ResponseLocationDTO>();
            CreateMap<ResponseLocationDTO, Location>();

            CreateMap<Location, CreateLocationDTO>();
            CreateMap<CreateLocationDTO,Location>();

            CreateMap<Location, UpdateLocationDTO>();
            CreateMap<UpdateLocationDTO,Location>();

            CreateMap<ResponseLocationDTO, CreateLocationDTO>();
            CreateMap<CreateLocationDTO, ResponseLocationDTO>();

            CreateMap<UpdateLocationDTO,  ResponseLocationDTO>();
            CreateMap<ResponseLocationDTO, UpdateLocationDTO>();
            
        }
    }
}
