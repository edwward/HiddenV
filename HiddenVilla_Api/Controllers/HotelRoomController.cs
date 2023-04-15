using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.Globalization;

namespace HiddenVilla_Api.Controllers
{
    [Route("api/[controller]")]
    public class HotelRoomController : Controller
    {
        private readonly IHotelRoomRepository _hotelRoomRepository;

        public HotelRoomController(IHotelRoomRepository hotelRoomRepository)
        {
            _hotelRoomRepository = hotelRoomRepository;
        }

        //zakladni httpget endpoint, vraci vsechny rooms z db
        [HttpGet]
        public async Task<IActionResult> GetHotelRooms(string? checkInDate = null, string? checkOutDate = null)
        {
            //z wasm projectu prijdou parametry pro checkIn a checkout datumy
            if (string.IsNullOrEmpty(checkInDate) || string.IsNullOrEmpty(checkOutDate))
            {
                return BadRequest(new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "All parameters must be supplied"
                });
            }

            if (!DateTime.TryParseExact(checkInDate, "MM.dd.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtCheckInDate))
            {
                return BadRequest(new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid CheckIn date format. valid format will be MM.dd.yyyy"
                });
            }

            if (!DateTime.TryParseExact(checkOutDate, "MM.dd.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtCheckOutDate))
            {
                return BadRequest(new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid CheckOut date format. valid format will be MM.dd.yyyy"
                });
            }

            //if everything is valid, retrieve all hotel rooms
            var allRooms = await _hotelRoomRepository.GetAllHotelRooms(checkInDate, checkOutDate);
            return Ok(allRooms);
        }


        //endpoint pro individualni room, pokud je roomId null, vrat error
        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetHotelRoom(int? roomId, string? checkInDate = null, string? checkOutDate = null)
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

            if (string.IsNullOrEmpty(checkInDate) || string.IsNullOrEmpty(checkOutDate))
            {
                return BadRequest(new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "All parameters must be supplied"
                });
            }

            if (!DateTime.TryParseExact(checkInDate, "MM.dd.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtCheckInDate))
            {
                return BadRequest(new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid CheckIn date format. valid format will be MM.dd.yyyy"
                });
            }

            if (!DateTime.TryParseExact(checkOutDate, "MM.dd.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtCheckOutDate))
            {
                return BadRequest(new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid CheckOut date format. valid format will be MM.dd.yyyy"
                });
            }

            var roomDetails = await _hotelRoomRepository.GetHotelRoom(roomId.Value, checkInDate, checkOutDate);

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
