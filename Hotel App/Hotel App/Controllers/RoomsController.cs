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
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
            return await _rooms.GetRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
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
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var modifiedRoom = await _rooms.UpdateRoom(id, room);

            return Ok(modifiedRoom);
        }

            // POST: api/Rooms
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Room>> PostRoom(Room room)
            {
                var AddRoom = _rooms.Create(room);

                return Ok(AddRoom);
            }

            // DELETE: api/Rooms/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteRoom(int id)
            {
                await _rooms.Delete(id);

                return NoContent();

               
            }

            //private bool RoomExists(int id)
            //{
            //    return _context.Room.Any(e => e.Id == id);
            //}
        }
    }

