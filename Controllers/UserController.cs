using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Wedding_RSVP.Models.ViewModels;

namespace Wedding_RSVP.Controllers
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
      public async Task<IActionResult> RsvpForm(UserAttendeesViewModel userAttendeesViewModel)
      {
         if (!ModelState.IsValid) return View();

         userAttendeesViewModel.User.Rsvpd = true; // If the logged in via this form then they are RSVPd
         _context.Users.Add(userAttendeesViewModel.User);
         // Add attendees to DB as well
         foreach (var attendee in userAttendeesViewModel.Attendees)
         {
            attendee.User = userAttendeesViewModel.User;
            _context.Attendees.Add(attendee);
         }

         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Success));
      }

      public IActionResult RegisteredList()
      {
         var usersViewModel = new UsersViewModel();
         usersViewModel.Users = _context.Users;

         return View(usersViewModel);
      }

      public IActionResult Success() => View();
   }
}
