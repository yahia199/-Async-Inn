using Hotel_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Room_App.Services.Interface
{
   public interface IRooms
    {
        public Task<Room> Create(Room room);

        public Task<List<Room>> GetRooms();

        public Task<Room> GetRoom(int id);

        public Task<Room> UpdateRoom(int id, Room room);

        public Task Delete(int id);
    }
}
