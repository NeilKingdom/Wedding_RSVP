using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Wedding_RSVP.Models
{
   public class User
   {
      [Column("UserID")]
      public int ID { get; set; }

      [Required(ErrorMessage="First name is required")]
      [BindProperty]
      [DisplayName("First Name")]
      [RegularExpression(@"^([a-zA-Z]{2,20})$",
         ErrorMessage = "Invalid first name")]
      public string FirstName { get; set; }

      [Required(ErrorMessage="Last name is required")]
      [BindProperty]
      [DisplayName("Last Name")]
      [RegularExpression(@"^([a-zA-Z]{2,20})$",
         ErrorMessage = "Invalid last name")]
      public string LastName { get; set; }

      [Required(ErrorMessage="Email address is required")]
      [BindProperty]
      [EmailAddress(ErrorMessage="Invalid e-mail")]
      public string Email { get; set; }

      [Required]
      [BindProperty]
      [Range(0, 5)]
      public int NumAttendees { get; set; }

#nullable enable
      [BindProperty]
      public string? SongRequest { get; set; }

      [BindProperty]
      public string? OtherInfo { get; set; }
#nullable disable

      public bool IsRsvpd { get; set; }

      // Navigation props
      public virtual IList<Gift> Gifts { get; set; }
      public virtual IList<Attendee> Attendees { get; set; }
   }
}
