using Microsoft.AspNetCore.Mvc;
using Wedding_RSVP.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using Wedding_RSVP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Wedding_RSVP.Controllers
{
   [Authorize]
   public class AccountController : Controller
   {
      private readonly WeddingDbContext _context;
      private UserManager<User> userManager;
      private SignInManager<User> signInManager;

      public AccountController(WeddingDbContext context, UserManager<User> userMgr, SignInManager<User> signinMgr)
      {
         _context = context;
         userManager = userMgr;
         signInManager = signinMgr;
      }

      // other methods
      public IActionResult AccessDenied()
      {
         return View();
      }

      [AllowAnonymous]
      public IActionResult GoogleLogin()
      {
         return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Google");
      }

      [AllowAnonymous]
      public async Task<IActionResult> GoogleResponse()
      {
         ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
         if (info == null) return RedirectToAction(nameof(GoogleLogin));

         // Attempt to login
         var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

         // Get user info from the claim
         string[] userInfo = { 
            info.Principal.FindFirst(ClaimTypes.Name).Value, 
            info.Principal.FindFirst(ClaimTypes.Email).Value 
         };

         // If login successful, proceed to registry
         if (result.Succeeded)
         {
            return View("~/Gift/GiftRegistry", userInfo);
         }
         else
         {
            User user = new User
            {
               Email = info.Principal.FindFirst(ClaimTypes.Email).Value
               //FirstName = info.Principal.FindFirst(ClaimTypes.Email).Value
            };

            // Add the user to the UserManager database
            IdentityResult identResult = await userManager.CreateAsync(user);
            if (identResult.Succeeded)
            {
               identResult = await userManager.AddLoginAsync(user, info);
               if (identResult.Succeeded)
               {
                  // Attempt sign in once more, now that user is registered in the UserManager DB
                  await signInManager.SignInAsync(user, false);
                  return View("~/Gift/GiftRegistry", userInfo);
               }
            }
            return AccessDenied();
         }
      }
   }
}
