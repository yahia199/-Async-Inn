using Hotel_App.Data;
using Hotel_App.Model;
using Hotel_App.Services.DTOs;
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

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                RoomId = roomId,
                AmenitiesId = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;

            await _context.SaveChangesAsync();

          

        }

        public async Task<RoomDTO> Create(RoomDTO room)
        {
            Room room1 = new Room
            {
                Id = room.ID,
                Name = room.Name,
                Layout = room.Layout
            };
            _context.Entry(room1).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await _context.Room.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            return await _context.Room.Select(X => new RoomDTO
            {
                ID = X.Id,
                Name = X.Name,
                Layout = X.Layout,
                Amenities = X.Amenities
                  .Select(Y => new AmenityDTO
                  {
                      ID = Y.Amenities.Id,
                      Name = Y.Amenities.Name
                  }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == id);

        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.Room.Select(X => new RoomDTO
            {
                ID = X.Id,
                Name = X.Name,
                Layout = X.Layout,
                Amenities = X.Amenities
                 .Select(Y => new AmenityDTO
                 {
                     ID = Y.Amenities.Id,
                     Name = Y.Amenities.Name
                 }).ToList()
            }).ToListAsync();

        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = await _context.RoomAmenities.Where(x => x.AmenitiesId == amenityId).FirstOrDefaultAsync();

            _context.Entry(roomAmenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO room)
        {

            Room room1 = new Room
            {
                Id = room.ID,
                Name = room.Name,
                Layout = room.Layout
            };
            _context.Entry(room1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

       
    }
}
