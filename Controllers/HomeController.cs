using Microsoft.AspNetCore.Mvc;

namespace Wedding_RSVP.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index() => View();

      public IActionResult RsvpForm() => View();

      public IActionResult GiftRegistry() => View();

      public IActionResult Success() => View();

      public IActionResult Error() => View();
   }
}
