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

      public async Task<IActionResult> DeleteGift(int id)
      {
         Gift gift = await _context.Gifts.FindAsync(id);
         if (gift == null) return NotFound();

         // Set availability to false and update DB
         gift.Available = false;
         _context.Gifts.Update(gift);
         await _context.SaveChangesAsync();
         return RedirectToPage("/Home/GiftRegistry");
      }

      public async Task<IActionResult> GetPrice(Gift gift)
      {
         string url = gift.SiteUrl;
         // TODO: Delete
         url = "https://www.amazon.ca/Remote-Control-Terrain-Running-Rotation/dp/B08DP2LPCY/ref=sr_1_5?crid=CKKEE4SC0CZZ&keywords=car&qid=1672688649&sprefix=car%2Caps%2C138&sr=8-5&th=1";
         var client = new HttpClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
			client.DefaultRequestHeaders.Accept.Clear();
         var html = await client.GetStringAsync(url);

			HtmlDocument htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(html);

			/*
				Inspecting the HTML reveals that the price is located within a span tag with the
				a-offscreen class. We use an XPath expression to grab all span elements containing
				this class.
			*/
			ViewBag.Price = htmlDoc.DocumentNode.SelectNodes("//span[contains(@class, 'a-offscreen')]");

         // Create UserGiftViewModel to return in GiftRegistry view
         UserGiftViewModel userGiftViewModel = new()
         {
            // TODO: Make this based on email in session data
            User = _context.Users.FirstOrDefault(),
            Gifts = _context.Gifts
         };
			return View("/Home/GiftRegistry", userGiftViewModel);
      }
   }
}
