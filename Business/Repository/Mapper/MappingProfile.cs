using AutoMapper;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Mapper
{
    //bude mapovat HotelRoom model na HotelRoomDto model
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapuj hotelroomdto na hotelroom, protoze jsou nazvy properties stejne v obou tridach, je mapovani takto jednoduche
            CreateMap<HotelRoomDto, HotelRoom>();
            CreateMap<HotelRoom, HotelRoomDto>();

            CreateMap<HotelAmenity, HotelAmenityDTO>().ReverseMap();
            CreateMap<HotelRoomImage, HotelRoomImageDto>().ReverseMap();
        }
    }
}
