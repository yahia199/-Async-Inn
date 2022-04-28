using Hotel_App.Data;
using Hotel_App.Model;
using Hotel_App.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel_App.Services.DTOs;

namespace Hotel_App.Services.Repositire
{
    public class HotelsRepo : IHotels
    {

        private readonly AsyncInnDbContext _context;

        public HotelsRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelDTO> Create(HotelDTO hotel)
        {
            Hotel hotel1 = new Hotel
            {
                Id = hotel.ID,
                Name = hotel.Name,
                StreetAdress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };


            _context.Entry(hotel1).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            HotelDTO hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            return await _context.Hotel.Select(x => new HotelDTO
            {
                ID = x.Id,
                Name = x.Name,
                StreetAddress = x.StreetAdress,
                City = x.City,
                State = x.State,
                Phone = x.Phone,
                Rooms = x.Rooms.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelId,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFrindly,
                    RoomID = x.RoomId,
                    Room = x.Room.Rooms.Select(x => new RoomDTO
                    {
                        ID = x.Room.Id,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.Amenities.Select(x => new AmenityDTO
                        {
                            ID = x.Amenities.Id,
                            Name = x.Amenities.Name
                        }).ToList()
                    }).FirstOrDefault()
                }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == id);

        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            return await _context.Hotel.Select(x => new HotelDTO
            {
                ID = x.Id,
                Name = x.Name,
                StreetAddress = x.StreetAdress,
                City = x.City,
                State = x.State,
                Phone = x.Phone,
                Rooms = x.Rooms.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelId,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFrindly,
                    RoomID = x.RoomId,
                    Room = x.Room.Rooms.Select(x => new RoomDTO
                    {
                        ID = x.Room.Id,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.Amenities.Select(x => new AmenityDTO
                        {
                            ID = x.Amenities.Id,
                            Name = x.Amenities.Name
                        }).ToList()
                    }).FirstOrDefault()
                }).ToList()
            }).ToListAsync();
        }

        public async Task<HotelDTO> UpdateHotel(int id , HotelDTO hotel)
        {
            Hotel hotel1 = new Hotel
            {
                Id = hotel.ID,
                Name = hotel.Name,
                StreetAdress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };
            _context.Entry(hotel1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
