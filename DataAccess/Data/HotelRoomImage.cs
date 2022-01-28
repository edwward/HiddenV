using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class HotelRoomImage
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomImageUrl { get; set; }
        
        [ForeignKey("RoomId")]
        //RoomId je foreign k HotelRoom tb, HotelRoom tb ma one-to-many relation k HotelRoomImage tb
        public virtual HotelRoom HotelRoom { get; set; }
    }
}
