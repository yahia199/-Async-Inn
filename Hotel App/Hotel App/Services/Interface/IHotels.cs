using Hotel_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Services.Interface
{
   public interface IHotels
    {
        public Task<Hotel> Create(Hotel hotel);

        public Task<List<Hotel>> GetHotels();

        public Task<Hotel> GetHotel(int id);

        public Task<Hotel> UpdateHotel(int id , Hotel hotel);

        public Task Delete(int id);

    }
}
