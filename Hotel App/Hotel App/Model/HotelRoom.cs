using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Model
{
    public class HotelRoom
    {
        public int Id { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public decimal Rate { get; set; }

        public bool PetFrindly { get; set; }



    }
}
