using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wedding_RSVP.Data;
using Wedding_RSVP.Models;

namespace Wedding_RSVP
{
   public class UserController : Controller
   {
      private readonly WeddingDbContext _context;

      public UserController(WeddingDbContext context)
      {
         _context = context;
      }

      public async Task<IActionResult> Index()
      {
         return View(await _context.Users.ToListAsync());
      }

      public async Task<IActionResult> Details(int id)
      {
         User user = await _context.Users.FindAsync(id);
         if (user == null) return NotFound();
         return View(user);
      }

      public IActionResult Create() => View();

      [HttpPost]
      public async Task<IActionResult> Create([Bind("ID, FirstName, LastName, Email, Attendees")] User user)
      {
         if (ModelState.IsValid)
         {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(user);
      }

      public async Task<IActionResult> Edit(int id)
      {
         User user = await _context.Users.FindAsync(id);
         if (user == null) return NotFound();
         return View(user);
      }

      [HttpPost]
      public async Task<IActionResult> Edit(int id, [Bind("FirstName, LastName, Email, Attendees")] User user)
      {
         if (id != user.ID)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               _context.Users.Update(user);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (await _context.Users.FindAsync(id) == null)
               {
                  return NotFound();
               }
               else
               {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         return View(user);
      }

      public async Task<IActionResult> Delete(int id)
      {
         User user = await _context.Users.FindAsync(id);
         if (user == null) return NotFound();
         return View(user);
      }

      [HttpPost]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         User user = await _context.Users.FindAsync(id);
         if (user == null) return NotFound();

         // Remove user from the db
         _context.Users.Remove(user);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }
   }
}
