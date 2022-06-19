using Hotel_App.Model;
using Hotel_App.Services.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>

    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Amenities> Amenities { get; set; }

        public DbSet<HotelRoom> HotelRoom { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        public DbSet<UserDto> userDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            base.OnModelCreating(modelBuilder);

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
            SeedRole(modelBuilder, "District Manager", "Create Hotel", "See Hotels", "Update Hotel", "Delete Hotel",
                                      "Create HotelRoom", "See HotelRooms", "Update HotelRooms", "Delete HotelRooms",
                                      "Create Rooms", "See Rooms", "Update Rooms", "Delete Rooms", "Create Amenity",
                                      "See Amenities", "Add Amenity to Room", "Delete Amenity From Room", "Update Amenity", "Delete Amenity",
                                      "Create Account for District Manager", "Create Account for Agent", "Create Account for Property Manager", "Create account for Anonymous User",
                                      "Add Room to Hotel");
            SeedRole(modelBuilder, "PropertyManager", "See Hotels", "Create HotelRoom", "See HotelRooms", "Update HotelRooms",
                                   "See Rooms", "See Amenities", "Add Amenity to Room", "Delete Amenity From Room", "Update Amenity",
                                   "Add Room to Hotel");
            SeedRole(modelBuilder, "Agent", "See HotelRooms", "Update HotelRooms", "See Amenities",
                                   "Add Amenity to Room", "Delete Amenity From Room");
            SeedRole(modelBuilder, "Anonymous", "See Hotels", "See HotelRooms", "See Rooms", "See Amenities");


          
          

        }

        private int nextId = 1; // we need this to generate a unique id on our own
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions", // This matches what we did in Startup.cs
      ClaimValue = permission
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
    }
  
}
