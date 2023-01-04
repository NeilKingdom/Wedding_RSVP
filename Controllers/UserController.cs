using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wedding_RSVP.Data;
using Wedding_RSVP.Models;

namespace Wedding_RSVP
{
   public class UserController : Controller
   {
      private readonly WeddingDbContext _context;

      public UserController(WeddingDbContext context)
      {
         _context = context;
      }

      public IActionResult RsvpForm() => View();

      [HttpPost]
      public async Task<IActionResult> RsvpForm([Bind("FirstName, LastName, Email, NumAttendees")]User user)
      {
         if (!ModelState.IsValid) return View();

         _context.Add(user);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Success));
      }

      public IActionResult Success() => View();
   }
}
