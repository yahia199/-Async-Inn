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
using Hotel_App.Services.DTOs;

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
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRoom()
        {
            return await _hotels.GetHotelRooms();
        }


        // GET: api/HotelRooms/5
        [HttpGet]
        [Route("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelId, int roomNumber)
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
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoomDTO hotelRoom)
        {
            if (id != hotelRoom.HotelID)
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
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom( HotelRoomDTO hotelRoom)
        {
            var RoomHotel = await _hotels.CreateHotelRoom( hotelRoom);

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

            return NoContent();
        }


        //private bool HotelRoomExists(int id)
        //{
        //    return _context.HotelRoom.Any(e => e.HotelId == id);
        //}
    }
}
