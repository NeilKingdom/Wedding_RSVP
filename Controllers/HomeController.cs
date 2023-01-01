using Microsoft.AspNetCore.Mvc;
using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Wedding_RSVP.Models.ViewModels;

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
      public IActionResult RsvpForm(User user)
      {
         if (!ModelState.IsValid) return View();

         // TODO: Save user information to DB

         return RedirectToAction(nameof(Success));
      }

      public IActionResult GiftRegistry()
      {
         UserGiftViewModel userGift = new()
         {
            User = _context.Users.FirstOrDefault(),
            Gifts = _context.Gifts
         };

         return View(userGift);
      }

      public IActionResult Success() => View();
   }
}
