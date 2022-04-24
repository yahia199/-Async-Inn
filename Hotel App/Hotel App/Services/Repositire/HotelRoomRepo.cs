using Hotel_App.Data;
using Hotel_App.Model;
using HotelRoom_App.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Services.Repositire
{
    public class HotelRoomRepo : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> CreateHotelRoom(int id, HotelRoom hotelRoom)
        {
            HotelRoom Room = new HotelRoom()
            {
                HotelId = id,
                RoomNumber = hotelRoom.RoomNumber,
                RoomId = hotelRoom.RoomId,
                Rate = hotelRoom.Rate,
                PetFrindly = hotelRoom.PetFrindly,
            };

            _context.Entry(hotelRoom).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return hotelRoom;

        }

        public async Task DeleteHotelRoom(int id, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRoom.FindAsync(RoomNumber, id);

            _context.Entry(hotelRoom).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetHotelRoom(int id, int RoomNumber)
        {
            return await _context.HotelRoom
                        .Where(h => h.HotelId == id && h.RoomNumber == RoomNumber)
                        .FirstOrDefaultAsync();


        }

        public async Task<List<HotelRoom>> GetHotelRooms(int id)
        {
            var hotelRooms = await _context.HotelRoom.Where(x => x.HotelId == id)
                                                                   .Include(x => x.Room)
                                                                   .ThenInclude(x => x.Rooms)
                                                                   .ToListAsync();

            List<HotelRoom> hotelRoomList = new List<HotelRoom>();

            foreach (var hotelRoom in hotelRooms)
                hotelRoomList.Add(await GetHotelRoom(hotelRoom.HotelId, hotelRoom.RoomNumber));

            return hotelRoomList;
        }

        public async Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;

        }


    }
}






