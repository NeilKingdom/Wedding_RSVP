using Wedding_RSVP.Data;
using Wedding_RSVP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

      //[NonAction]
      [HttpPost]
      [Route("{accepts}")]
      public async Task<IActionResult> RsvpForm(String accepts, UserAttendeesViewModel userAttendeesViewModel)
      {
         if (!ModelState.IsValid) return View();
      
         if (accepts == "true") 
         {
            userAttendeesViewModel.User.IsRsvpd = true; 
         }
         else if (accepts == "false")
         {
            userAttendeesViewModel.User.IsRsvpd = false; 
            // Disregard attendees if the user is not RSVPd
            userAttendeesViewModel.User.NumAttendees = 0;
            userAttendeesViewModel.Attendees = null;
         }
         
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

         // If email already exists, the DB will throw an exception
         try 
         {
            await _context.SaveChangesAsync();
         } 
         catch(Microsoft.EntityFrameworkCore.DbUpdateException) 
         {
            ViewBag.EmailError = "true";
            return View();
         }
         return RedirectToAction(nameof(Success));
      }

      public IActionResult Success() => View();
   }
}
