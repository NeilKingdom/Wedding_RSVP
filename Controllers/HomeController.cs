using Microsoft.AspNetCore.Mvc;
using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Wedding_RSVP.Models.ViewModels;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;

namespace Wedding_RSVP.Controllers
{
   public class HomeController : Controller
   {
      private readonly WeddingDbContext _context;

      // Default constructor
      public HomeController(WeddingDbContext context)
      {
         _context = context;
      }

      public IActionResult Index() => View();

      public IActionResult RsvpForm() => View();

      [HttpPost]
      public async Task<IActionResult> RsvpForm([Bind("FirstName, LastName, Email, NumAttendees")]User user)
      {
         if (!ModelState.IsValid) return View();

         _context.Add(user);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Success));
      }

      public IActionResult GiftRegistry()
      {
         UserGiftViewModel userGift = new()
         {
            // TODO: Set user to the user matching email in session data
            User = _context.Users.FirstOrDefault(),
            Gifts = _context.Gifts
         };

         return View(userGift);
      }

      public IActionResult Success() => View();
   }
}
