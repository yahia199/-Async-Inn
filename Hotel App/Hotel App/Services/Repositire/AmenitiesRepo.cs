using Hotel_App.Data;
using Hotel_App.Model;
using Hotel_App.Services.DTOs;
using Hotel_App.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amenities_App.Services.Repositire
{
    public class AmenitiesRepo : IAmenities
    {

        private readonly AsyncInnDbContext _context;

        public AmenitiesRepo(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<AmenityDTO> Create(AmenityDTO amenities)
        {
            Amenities amenities1 = new Amenities
            {
                Id = amenities.ID,
                Name = amenities.Name

            };
            _context.Entry(amenities1).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task Delete(int id)
        {
            AmenityDTO amenities = await GetAmenities(id);
            _context.Entry(amenities).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<AmenityDTO> GetAmenities(int id)
        {
            return await _context.Amenities.Select(amenities => new AmenityDTO { ID = amenities.Id, Name = amenities.Name }).FirstOrDefaultAsync();
        }

        public async Task<List<AmenityDTO>> GetAmenitiess()
        {
            return await _context.Amenities.Select(amenities => new AmenityDTO { ID = amenities.Id, Name = amenities.Name }).ToListAsync();

        }

        public async Task<AmenityDTO> UpdateAmenities(int id, AmenityDTO amenities)
        {
            Amenities amenities1 = new Amenities
            {
                Id = amenities.ID,
                Name = amenities.Name

            };
            _context.Entry(amenities1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenities;
        }
    }
}
