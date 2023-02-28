using System.Runtime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Wedding_RSVP.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
