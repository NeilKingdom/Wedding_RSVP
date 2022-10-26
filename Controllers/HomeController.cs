using Microsoft.AspNetCore.Mvc;

namespace Wedding_RSVP.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index() => View();

      public IActionResult Error() => View();
   }
}
