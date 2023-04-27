using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Wedding_RSVP.Models
{
   public class Attendee
   {
      [Column("AttendeeID")]
      public int ID { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      [Required]
      [BindProperty]
      // NOTE: Regex is handled by jQuery
      public string FullName {
         get => $"{FirstName} {LastName}";
         set {
            string[] split = value.Split(" ");
            FirstName = split[0];
            LastName = split[1];
         }
      }

      // Navigation props
      public virtual User User { get; set; }
   }
}
