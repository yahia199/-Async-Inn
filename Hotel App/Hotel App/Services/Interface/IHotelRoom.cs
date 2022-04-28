using Hotel_App.Model;
using Hotel_App.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoom_App.Services.Interface
{
  public interface IHotelRoom
    {
        public Task<HotelRoomDTO> CreateHotelRoom( HotelRoomDTO hotelRoom);

        public Task<List<HotelRoomDTO>> GetHotelRooms();

        public Task<HotelRoomDTO> GetHotelRoom(int id, int RoomNumber);

        public Task<HotelRoomDTO> UpdateHotelRoom(HotelRoomDTO hotelRoom);

        public Task DeleteHotelRoom(int RoomNumber,int id);
    }
}
