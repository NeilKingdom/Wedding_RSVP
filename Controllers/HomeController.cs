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
      public IActionResult Index() => View();
   }
}
