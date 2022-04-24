using Hotel_App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Amenities> Amenities { get; set; }

        public DbSet<HotelRoom> HotelRoom { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Hotel 1",City = "Amman" , Country = "Jordan",Phone = 077,State = "Amman",StreetAdress = "University str."},
              new Hotel { Id = 2, Name = "Hotel 2", City = "Irbid", Country = "Jordan", Phone = 078, State = "Irbid", StreetAdress = "University str." },
              new Hotel { Id = 3, Name = "Hotel 3", City = "Zarqa", Country = "Jordan", Phone = 079, State = "Amman", StreetAdress = "University str." }

            );
            modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Name = "Room 1" , Layout = 1},
            new Room { Id = 2, Name = "Room 2" , Layout = 2},
            new Room { Id = 3, Name = "Room 3" , Layout = 3}

          );
            modelBuilder.Entity<Amenities>().HasData(
            new Amenities { Id = 1, Name = "Amenity 1" },
            new Amenities { Id = 2, Name = "Amenity 2" },
            new Amenities { Id = 3, Name = "Amenity 3" }

          );
            modelBuilder.Entity<RoomAmenities>().HasKey(
                x => new { x.AmenitiesId, x.RoomId });

            modelBuilder.Entity<HotelRoom>().HasKey(
                x => new { x.HotelId, x.RoomNumber });


        }
    }
  
}
