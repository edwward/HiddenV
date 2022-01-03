using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IHotelRoomRepository
    {
        //interface pro crud operace
        public Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto);
        public Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto);
        public Task<HotelRoomDto> GetHotelRoom(int roomId);
        public Task<int> DeleteHotelRoom(int roomId);
        public Task<IEnumerable<HotelRoomDto>> GetAllHotelRoom();
        public Task<HotelRoomDto> IsRoomUnique(string name);
    }
}
