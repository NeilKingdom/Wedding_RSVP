using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using Wedding_RSVP.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Wedding_RSVP.Controllers
{
   //[Authorize]
   public class GiftController : Controller
   {
      private readonly WeddingDbContext _context;

      public GiftController(WeddingDbContext context)
      {
         _context = context;
      }

      [AllowAnonymous]
      public IActionResult OnGet()
      {
         return Challenge(new AuthenticationProperties { RedirectUri = Url.Action("GiftRegistry") }, 
               GoogleDefaults.AuthenticationScheme); 
      }

      public IActionResult GiftRegistry()
      {
         UserGiftsViewModel userGift = new()
         {
            User = new(),
            Gifts = new List<Gift>()
         };

         return View(userGift);
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
