using Hotel_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoom_App.Services.Interface
{
  public interface IHotelRoom
    {
        public Task<HotelRoom> CreateHotelRoom(int id,HotelRoom hotelRoom);

        public Task<List<HotelRoom>> GetHotelRooms(int id);

        public Task<HotelRoom> GetHotelRoom(int id, int RoomNumber);

        public Task<HotelRoom> UpdateHotelRoom( HotelRoom hotelRoom);

        public Task DeleteHotelRoom(int RoomNumber,int id);
    }
}
