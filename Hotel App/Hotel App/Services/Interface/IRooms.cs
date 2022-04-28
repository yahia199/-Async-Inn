using Hotel_App.Model;
using Hotel_App.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Room_App.Services.Interface
{
   public interface IRooms
    {
        public Task<RoomDTO> Create(RoomDTO room);

        public Task<List<RoomDTO>> GetRooms();

        public Task<RoomDTO> GetRoom(int id);

        public Task<RoomDTO> UpdateRoom(int id, RoomDTO room);

        public Task Delete(int id);

        public Task AddAmenityToRoom(int roomId, int amenityId);

        public Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
