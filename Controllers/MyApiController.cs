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
   [Route("api")]
   public class MyApiController : ControllerBase 
   {
      private readonly WeddingDbContext _context;

      public MyApiController(WeddingDbContext context)
      {
         _context = context;
      }

      /* RESTful endpoint for displaying list of users */
      [Authorize]
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<User>>> GetUsers()
      {
         return Ok(await _context.Users.ToListAsync()); 
      }

      /* RESTful endpoint for displaying a specific user */
      [Authorize]
      [HttpGet("{id}")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<User>> GetUser(int id)
      {
         User user = await _context.Users.FindAsync(id);
         if (user == null) return NotFound();
         return Ok(user);
      }
   }
}
