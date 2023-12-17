using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business.DTOs.Holiday;
using TravelAgency.Entities.Entities;

namespace TravelAgency.Business.AutoMappers
{
    public class HolidayProfile : Profile
    {
        public HolidayProfile()
        {
            CreateMap<Holiday, ResponseHolidayDTO>();
            CreateMap<ResponseHolidayDTO, Holiday>();

            CreateMap<Holiday, CreateHolidayDTO>()
            .ForMember(dest => dest.Location, opt => opt.Ignore());
            CreateMap<CreateHolidayDTO, Holiday>()
            .ForMember(dest => dest.Location, opt => opt.Ignore());

            CreateMap<Holiday, UpdateHolidayDTO>()
            .ForMember(dest => dest.Location, opt => opt.Ignore());
            CreateMap<UpdateHolidayDTO, Holiday>()
            .ForMember(dest => dest.Location, opt => opt.Ignore());

            CreateMap<ResponseHolidayDTO, CreateHolidayDTO>();
            CreateMap<CreateHolidayDTO, ResponseHolidayDTO>();

            CreateMap<UpdateHolidayDTO, ResponseHolidayDTO>()
            .ForMember(dest => dest.Location, opt => opt.Ignore());
            CreateMap<ResponseHolidayDTO, UpdateHolidayDTO>()
            .ForMember(dest => dest.Location, opt => opt.Ignore());
        }
    }
}
