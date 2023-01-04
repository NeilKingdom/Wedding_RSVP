using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using HtmlAgilityPack; // Used for parsing HTML
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using Wedding_RSVP.Models.ViewModels;

namespace Wedding_RSVP
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
         UserGiftViewModel userGift = new()
         {
            // TODO: Set user to the user matching email in session data
            User = _context.Users.FirstOrDefault(),
            Gifts = _context.Gifts
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
