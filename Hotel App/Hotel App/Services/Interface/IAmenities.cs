using Hotel_App.Model;
using Hotel_App.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Services.Interface
{
   public interface IAmenities
    {
        public Task<AmenityDTO> Create(AmenityDTO amenities);

        public Task<List<AmenityDTO>> GetAmenitiess();

        public Task<AmenityDTO> GetAmenities(int id);

        public Task<AmenityDTO> UpdateAmenities(int id, AmenityDTO amenities);

        public Task Delete(int id);
    }
}
