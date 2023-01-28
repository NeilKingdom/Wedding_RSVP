using Microsoft.AspNetCore.Mvc;
using System.Runtime;

namespace Wedding_RSVP.Controllers
{
   public class HomeController : Controller
   {
      private const string _weddingDate = "08/26/2023";
      private DateTime _weddingDateTime;

      public HomeController()
      {
         _weddingDateTime = Convert.ToDateTime(_weddingDate);
         ViewBag.Date = _weddingDate;
      }

      public IActionResult Index()
      {
         ViewBag.Date = _weddingDate;
         return View();
      }

      public IActionResult SwapDate()
      {
         var currDate = DateTime.Now;
         if (ViewBag.Date == _weddingDate) // Display as a countdown
            ViewBag.Date = "Days Remaining: " + (int)(_weddingDateTime - currDate).TotalDays;
         else // Display in date format
            ViewBag.Date = _weddingDate;

         return View(nameof(Index));
      }
   }
}
