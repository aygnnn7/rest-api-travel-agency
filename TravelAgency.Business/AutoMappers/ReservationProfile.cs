using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAcces.DTOs.Reservation;
using TravelAgency.Entities.Entities;

namespace TravelAgency.Business.AutoMappers
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ResponseReservationDTO>();
            CreateMap<ResponseReservationDTO, Reservation>();

            CreateMap<Reservation, CreateReservationDTO>()
                 .ForMember(dest => dest.Holiday, opt => opt.Ignore());
            CreateMap<CreateReservationDTO, Reservation>()
                 .ForMember(dest => dest.Holiday, opt => opt.Ignore());

            CreateMap<Reservation, UpdateReservationDTO>()
                 .ForMember(dest => dest.Holiday, opt => opt.Ignore());
            CreateMap<UpdateReservationDTO, Reservation>()
                 .ForMember(dest => dest.Holiday, opt => opt.Ignore());

            CreateMap<ResponseReservationDTO, CreateReservationDTO>();
            CreateMap<CreateReservationDTO, ResponseReservationDTO>();

            CreateMap<UpdateReservationDTO, ResponseReservationDTO>()
                 .ForMember(dest => dest.Holiday, opt => opt.Ignore());
            CreateMap<ResponseReservationDTO, UpdateReservationDTO>()
                 .ForMember(dest => dest.Holiday, opt => opt.Ignore());
        }
    }
}
