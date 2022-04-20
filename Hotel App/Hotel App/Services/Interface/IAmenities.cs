using Hotel_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Services.Interface
{
   public interface IAmenities
    {
        public Task<Amenities> Create(Amenities amenities);

        public Task<List<Amenities>> GetAmenitiess();

        public Task<Amenities> GetAmenities(int id);

        public Task<Amenities> UpdateAmenities(int id, Amenities amenities);

        public Task Delete(int id);
    }
}
