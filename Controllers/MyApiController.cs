using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Wedding_RSVP.Controllers
{
   [ApiController]
   [Route("api/[controller]/[action]")] 
   public class MyApiController : ControllerBase 
   {
      private readonly WeddingDbContext _context;

      public MyApiController(WeddingDbContext context)
      {
         _context = context;
      }

      [Authorize]
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<int>> GetCount()
      {
         int countUsers = await _context.Users.CountAsync();
         int countAttendees = await _context.Attendees.CountAsync();
         return Ok(countUsers + countAttendees);
      }

      [Authorize]
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<User>>> GetUsers()
      {
         return Ok(await _context.Users.ToListAsync()); 
      }

      [Authorize]
      [HttpGet("{id}")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<User>> GetUser(int id)
      {
         User user = await _context.Users.FindAsync(id);
         if (user == null) return NotFound();
         return Ok(user);
      }

      [Authorize]
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<User>>> GetGifts()
      {
         return Ok(await _context.Gifts.ToListAsync()); 
      }

      [Authorize]
      [HttpDelete("{id}")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<IActionResult> DeleteUser(int id)
      {
         var user = await _context.Users.FindAsync(id);
         if (user == null)
         {
            return NotFound();
         }

         // First, delete any attendees associated with user
         foreach (var attendee in user.Attendees)
         {
            _context.Attendees.Remove(attendee);
         }

         _context.Users.Remove(user);
         await _context.SaveChangesAsync();

         return NoContent();
      }
   }
}
