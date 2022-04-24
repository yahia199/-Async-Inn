using Hotel_App.Data;
using Hotel_App.Model;
using Microsoft.EntityFrameworkCore;
using Room_App.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Services.Repositire
{
    public class RoomsRepo : IRooms
    {
        private readonly AsyncInnDbContext _context;

        public RoomsRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Room> AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                RoomId = roomId,
                AmenitiesId = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;

            await _context.SaveChangesAsync();

            var AddAmenity = await GetRoom(roomId);

            return AddAmenity;

        }

        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            //Room room = await _context.Room.FindAsync(id);
            //return room;
            Room room = await _context.Room.FindAsync(id);

            var roomAmenities = await _context.RoomAmenities
                .Where(x => x.RoomId == id)
                .Include(y => y.Amenities)
                .ToListAsync();

            room.Amenities = roomAmenities;

            return room;



        }

        public async Task<List<Room>> GetRooms()
        {
            //var rooms = await _context.Room.ToListAsync();
            //return rooms;

            var rooms = await _context.Room.Include(x => x.Amenities)
                                           .ThenInclude(x => x.Amenities)
                                           .ToListAsync();

            List<Room> roomList = new List<Room>();

            foreach (var room in rooms)
                roomList.Add(await GetRoom(room.Id));

            return roomList;

        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = await _context.RoomAmenities.Where(x => x.AmenitiesId == amenityId).FirstOrDefaultAsync();

            _context.Entry(roomAmenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

       
    }
}
