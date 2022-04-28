using Hotel_App.Data;
using Hotel_App.Model;
using Hotel_App.Services.DTOs;
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

        public async Task<HotelRoomDTO> CreateHotelRoom( HotelRoomDTO hotelRoom)
        {

            HotelRoom Room = new HotelRoom()
            {
                HotelId = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                RoomId = hotelRoom.HotelID,
                Rate = hotelRoom.Rate,
                PetFrindly = hotelRoom.PetFriendly,
            };

            _context.Entry(Room).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return hotelRoom;

        }

        public async Task DeleteHotelRoom(int id, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRoom.FindAsync(RoomNumber, id);

            _context.Entry(hotelRoom).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int id, int RoomNumber)
        {
            return await _context.HotelRoom.Select(X => new HotelRoomDTO()
            {
                HotelID = X.HotelId,
                RoomNumber = X.RoomNumber,
                Rate = X.Rate,
                PetFriendly = X.PetFrindly,
                RoomID = X.RoomId,
                Room = new RoomDTO()
                {
                    ID = X.Room.Id,
                    Name = X.Room.Name,
                    Layout = X.Room.Layout,
                    Amenities = X.Room.Amenities
                   .Select(Y => new AmenityDTO()
                   {
                       ID = Y.Amenities.Id,
                       Name = Y.Amenities.Name
                   }).ToList()
                }
            }).FirstOrDefaultAsync(x => x.HotelID == id && x.RoomNumber == RoomNumber);



        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
            return await _context.HotelRoom.Select(X => new HotelRoomDTO()
            {
                HotelID = X.HotelId,
                RoomNumber = X.RoomNumber,
                Rate = X.Rate,
                PetFriendly = X.PetFrindly,
                RoomID = X.RoomId,
                Room = new RoomDTO()
                {
                    ID = X.Room.Id,
                    Name = X.Room.Name,
                    Layout = X.Room.Layout,
                    Amenities = X.Room.Amenities
                    .Select(Y => new AmenityDTO()
                    {
                        ID = Y.Amenities.Id,
                        Name = Y.Amenities.Name
                    }).ToList()
                }
            }).ToListAsync();
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(HotelRoomDTO hotelRoom)
        {
            HotelRoom Room = new HotelRoom()
            {
                HotelId = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                RoomId = hotelRoom.HotelID,
                Rate = hotelRoom.Rate,
                PetFrindly = hotelRoom.PetFriendly,
            };
            _context.Entry(Room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;

        }


    }
}






