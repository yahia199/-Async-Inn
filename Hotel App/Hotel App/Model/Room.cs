using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Model
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Layout { get; set; }

        public IList<RoomAmenities> Amenities { get; set; }
        public IList<HotelRoom> Rooms { get; set; }




    }
}
