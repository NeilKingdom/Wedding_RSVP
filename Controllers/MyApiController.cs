using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Wedding_RSVP.Controllers
{
   [ApiController]
   [Route("api")] // Acts the same as RoutePrefix in ASP MVC < 6
   public class MyApiController : ControllerBase 
   {
      private readonly WeddingDbContext _context;

      public MyApiController(WeddingDbContext context)
      {
         _context = context;
      }

      [Authorize]
      [Route("count")]
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

      /* RESTful endpoint for displaying list of users */
      [Authorize]
      [Route("users")]
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<User>>> GetUsers()
      {
         return Ok(await _context.Users.ToListAsync()); 
      }

      /* RESTful endpoint for displaying a specific user */
      [Authorize]
      [Route("user/{id}")]
      [HttpGet]
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

      /* RESTful endpoint for displaying gifts */
      [Authorize]
      [Route("gifts")]
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<User>>> GetGifts()
      {
         return Ok(await _context.Gifts.ToListAsync()); 
      }

      [Authorize]
      [Route("delete/{id}")]
      [HttpDelete]
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
