using HiddenVilla_Client.Service.IService;
using Models;
using Newtonsoft.Json;

namespace HiddenVilla_Client.Service
{
    //class for calling api which is in Api project
    public class HotelRoomService : IHotelRoomService
    {
        private readonly HttpClient _httpClient;

        public HotelRoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;    
        }

        public Task<HotelRoomDto> GetHotelRoomDetails(int roomId, string checkInDate, string checkOutDate)
        {
            throw new NotImplementedException();
        }

        //retrieve all hotel rooms and display them in wasm application
        public async Task<IEnumerable<HotelRoomDto>> GetHotelRooms(string checkInDate, string checkOutDate)
        {
            //zde volam hotelRoomcontroller z api HotelRoomController.cs
            var response = await _httpClient.GetAsync($"api/hotelroom?checkInDate={checkInDate}&checkOutDate={checkOutDate}");
            var content = await response.Content.ReadAsStringAsync();
            var rooms = JsonConvert.DeserializeObject<IEnumerable<HotelRoomDto>>(content);
            return rooms;
        }
    }
}
