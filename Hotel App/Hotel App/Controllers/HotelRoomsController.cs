using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_App.Data;
using Hotel_App.Model;
using HotelRoom_App.Services.Interface;

namespace Hotel_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotels;

        public HotelRoomsController(IHotelRoom hotels)
        {
            _hotels = hotels;
        }

        // GET: api/HotelRooms
        [HttpGet]
        [Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRoom(int hotelId)
        {
            return await _hotels.GetHotelRooms(hotelId);
        }


        // GET: api/HotelRooms/5
        [HttpGet]
        [Route("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _hotels.GetHotelRoom(hotelId, roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }


            // PUT: api/HotelRooms/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut]
            [Route("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelId)
            {
                return BadRequest();
            }
             var updateRoom =    await _hotels.UpdateHotelRoom(hotelRoom);

            return Ok(updateRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int id, HotelRoom hotelRoom)
        {
            var RoomHotel = await _hotels.CreateHotelRoom(id, hotelRoom);

            return Ok(RoomHotel);

        }

        // DELETE: api/HotelRooms/5
        [HttpDelete]
        [Route("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int id, int roomNumber)
        {
            var RoomHotel = await _hotels.GetHotelRoom(id, roomNumber);
            if (RoomHotel == null)
            {
                return NotFound();
            }

            await _hotels.DeleteHotelRoom(id, roomNumber);

            return RoomHotel;
        }


        //private bool HotelRoomExists(int id)
        //{
        //    return _context.HotelRoom.Any(e => e.HotelId == id);
        //}
    }
}
