using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace HiddenVilla_Api.Controllers
{
    [Route("api/[controller]")]
    public class HomeRoomController : Controller
    {
        private readonly IHotelRoomRepository _hotelRoomRepository;

        public HomeRoomController(IHotelRoomRepository hotelRoomRepository)
        {
            _hotelRoomRepository = hotelRoomRepository;
        }

        //zakladni httpget endpoint, vraci vsechny rooms z db
        [HttpGet]
        public async Task<IActionResult> GetHotelRooms()
        {
            var allRooms = await _hotelRoomRepository.GetAllHotelRooms();
            return Ok(allRooms);
        }


        //endpoint pro individualni room, pokud je roomId null, vrat error
        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetHotelRoom(int? roomId)
        {
            if (roomId == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "Error",
                    ErrorMessage = "Invalid Room Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });  
            }

            var roomDetails = await _hotelRoomRepository.GetHotelRoom(roomId.Value);

            if (roomDetails == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "Error",
                    ErrorMessage = "Invalid Room Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(roomDetails);
        }
    }
}
