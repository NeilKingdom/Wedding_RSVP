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

      [Route("User/RsvpForm/{code?}")]
      [HttpGet]
      public async Task<IActionResult> RsvpForm(string code) {
         if (string.IsNullOrEmpty(code))
         {
            return View();
         }
         else
         {
            UserCode userCode = await _context.UserCodes.Where(c => c.Code == code).FirstOrDefaultAsync();
            if (userCode == null) return View();

            User user = new() { UserCode = userCode };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            // Need to re-fetch user from DB since it had to assign the user's ID
            user = await _context.Users.FindAsync(user);
            userCode.UserID = user.ID;

            UserAttendeesViewModel userAttendees = new() { User = user };
            return View(nameof(RsvpForm), userAttendees);
         }
      }

      [HttpPost]
      public async Task<IActionResult> RsvpForm(UserAttendeesViewModel userAttendeesViewModel)
      {
         if (!ModelState.IsValid) return View();

         _context.Users.Add(userAttendeesViewModel.User);
         // Add attendees to DB as well
         if (userAttendeesViewModel.Attendees != null
               && userAttendeesViewModel.Attendees.Count() > 0)
         {
            foreach (var attendee in userAttendeesViewModel.Attendees)
            {
               attendee.User = userAttendeesViewModel.User;
               _context.Attendees.Add(attendee);
            }
         }

         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Success));
      }

      public IActionResult RegisteredList()
      {
         var usersViewModel = new UsersViewModel();
         usersViewModel.Users = _context.Users.OrderBy(user => user.FirstName);

         return View(usersViewModel);
      }

      public IActionResult Success() => View();
   }
}
