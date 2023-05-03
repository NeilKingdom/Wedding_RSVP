using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Wedding_RSVP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Wedding_RSVP.Controllers
{
   public class GiftController : Controller
   {
      private readonly WeddingDbContext _context;

      public GiftController(WeddingDbContext context)
      {
         _context = context;
      }

      public IActionResult GiftRegistry()
      {
         GiftsViewModel giftsViewModel = new() {
            Gifts = _context.Gifts.Where(c => c.Available == true)
         };
         return View(giftsViewModel);
      }

      public IActionResult RegisteredGifts()
      {
         UserGiftsViewModel userGift = new()
         {
            User = new(),
            Gifts = new List<Gift>()
         };

         return View(userGift);
      }

      public async Task<IActionResult> DeleteGift(int id)
      {
         Gift gift = await _context.Gifts.FindAsync(id);
         if (gift == null) return NotFound();

         // Set availability to false and update DB
         gift.Available = false;
         _context.Gifts.Update(gift);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(GiftRegistry));
      }
   }
}
