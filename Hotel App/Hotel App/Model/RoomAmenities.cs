﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Model
{
    public class RoomAmenities
    {
        public int Id { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("AmenitiesId")]
        public Amenities Amenities { get; set; }

        public int AmenitiesId { get; set; }


    }
}
