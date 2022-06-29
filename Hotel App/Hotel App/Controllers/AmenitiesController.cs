using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_App.Data;
using Hotel_App.Model;
using Hotel_App.Services.Interface;
using Hotel_App.Services.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenities _amenities;

        public AmenitiesController(IAmenities amenities)
        {
            _amenities = amenities;
        }

        // GET: api/Amenities
        [HttpGet]
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "PropertyManager")]
        [Authorize(Roles = "Anonymous")]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            return Ok( await _amenities.GetAmenitiess());
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "PropertyManager")]
        [Authorize(Roles = "Anonymous")]


        public async Task<ActionResult<AmenityDTO>> GetAmenities(int id)
        {
            var amenities = await _amenities.GetAmenities(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return Ok( amenities);
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "PropertyManager")]


        public async Task<IActionResult> PutAmenities(int id, AmenityDTO amenities)
        {
            if (id != amenities.ID)
            {
                return BadRequest();
            }

            var modifiedAmenities = await _amenities.UpdateAmenities(id, amenities);

            return Ok(modifiedAmenities);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "PropertyManager")]
        [Authorize(Roles = "Agent")]
        public async Task<ActionResult<AmenityDTO>> PostAmenities(AmenityDTO amenities)
        {
            var AddAmenities = _amenities.Create(amenities);

            return Ok(AddAmenities);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Delete Amenity")]
        public async Task<IActionResult> DeleteAmenities(int id)
        {
            await _amenities.Delete(id);

            return NoContent();
        }

        //private bool AmenitiesExists(int id)
        //{
        //    return _context.Amenities.Any(e => e.Id == id);
        //}
    }
}
