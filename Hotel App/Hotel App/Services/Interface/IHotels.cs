using Hotel_App.Model;
using Hotel_App.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Services.Interface
{
   public interface IHotels
    {
        public Task<HotelDTO> Create(HotelDTO hotel);

        public Task<List<HotelDTO>> GetHotels();

        public Task<HotelDTO> GetHotel(int id);

        public Task<HotelDTO> UpdateHotel(int id , HotelDTO hotel);

        public Task Delete(int id);

    }
}
