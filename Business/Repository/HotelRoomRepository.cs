using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        //mapper musi byt i v program.cs
        public HotelRoomRepository(AppDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto)
        {
            var hotelRoom = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";

            var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelRoom);
            await _db.SaveChangesAsync();

            return _mapper.Map<HotelRoom, HotelRoomDto>(addedHotelRoom.Entity);
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDetails = await _db.HotelRooms.FindAsync(roomId);
            if (roomDetails != null) 
            {
                _db.HotelRooms.Remove(roomDetails);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<HotelRoomDto>> GetAllHotelRoom()
        {
            try
            {
                IEnumerable<HotelRoomDto> hotelRoomsDto = 
                    _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDto>> (_db.HotelRooms);

                return hotelRoomsDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> GetHotelRoom(int roomId)
        {
            try
            {
                HotelRoomDto hotelRoom = _mapper.Map<HotelRoom, HotelRoomDto>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Id == roomId));

                return hotelRoom;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //if unique return null else returns the room object
        public async Task<HotelRoomDto> IsRoomUnique(string name)
        {
            try
            {
                HotelRoomDto hotelRoom = _mapper.Map<HotelRoom, HotelRoomDto>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

                return hotelRoom;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto)
        {
            try
            {
                if (roomId == hotelRoomDto.Id)
                {
                    var roomDetails = await _db.HotelRooms.FindAsync(roomId);
                    var room = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto, roomDetails);
                    room.UpdatedBy = "";
                    room.UpdatedDate = DateTime.Now;
                    var updatedRoom = _db.HotelRooms.Update(room);

                    await _db.SaveChangesAsync();

                    return _mapper.Map<HotelRoom, HotelRoomDto>(updatedRoom.Entity);
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
