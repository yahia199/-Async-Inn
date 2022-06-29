using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_App.Data;
using Hotel_App.Model;
using Room_App.Services.Interface;
using Hotel_App.Services.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRooms _rooms;

        public RoomsController(IRooms rooms)
        {
            _rooms = rooms;
        }

        // GET: api/Rooms
        [HttpGet]
  [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRoom()
        {
            return await _rooms.GetRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
[AllowAnonymous]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _rooms.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "Update Rooms")]

        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            var modifiedRoom = await _rooms.UpdateRoom(id, room);

            return Ok(modifiedRoom);
        }

            // POST: api/Rooms
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
        [Authorize(Policy = "Create Rooms")]

        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
            {
                var AddRoom = await _rooms.Create(room);

                return Ok(AddRoom);
            }

            // DELETE: api/Rooms/5
            [HttpDelete("{id}")]
        [Authorize(Policy = "Delete Rooms")]

        public async Task<IActionResult> DeleteRoom(int id)
            {
                await _rooms.Delete(id);

                return NoContent();

               
            }
        [HttpDelete]
        [Route("{roomId}/Amenity/{amenityId}")]
        [Authorize(Policy = "Delete Amenity From Room")]

        public async Task<IActionResult> RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            await _rooms.RemoveAmentityFromRoom(roomId, amenityId);

            return NoContent();
        }
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        [Authorize(Policy = "Add Amenity to Room")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
             await _rooms.AddAmenityToRoom(roomId, amenityId);

            return NoContent();
        }



        //private bool RoomExists(int id)
        //{
        //    return _context.Room.Any(e => e.Id == id);
        //}
    }
}

