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
    public class HotelsController : ControllerBase
    {
        private readonly IHotels _hotels;

        public HotelsController(IHotels hotels)
        {
            _hotels = hotels;
        }

        // GET: api/Hotels
        [HttpGet]
     [AllowAnonymous]

        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotel()
        {
            return await _hotels.GetHotels();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
     [AllowAnonymous]

        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _hotels.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy  = "Update Hotel")]

        public async Task<IActionResult> PutHotel(int id, HotelDTO hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }
            var modifiedHotel = await _hotels.UpdateHotel(id, hotel);

            return Ok(modifiedHotel);
        }

        

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "Create Hotel")]

        public async Task<ActionResult<Hotel>> PostHotel(HotelDTO hotel)
        {
            await _hotels.Create(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);

        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        [Authorize(Policy  = "Delete Hotel")]

        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotels.Delete(id);

            return NoContent();
        }

        //private bool HotelExists(int id)
        //{
        //    return _context.Hotel.Any(e => e.Id == id);
        //}
    }
}
