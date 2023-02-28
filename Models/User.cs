using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Wedding_RSVP.Models
{
   public class User : IdentityUser
   {
//      [Column("UserID")]
//      public int ID { get; set; }

      [Required(ErrorMessage="First name is required")]
      [BindProperty]
      [DisplayName("First Name")]
      [StringLength(20, MinimumLength = 2)]
      public string FirstName { get; set; }

      [Required(ErrorMessage="Last name is required")]
      [BindProperty]
      [DisplayName("Last Name")]
      [StringLength(20, MinimumLength = 2)]
      public string LastName { get; set; }

//      [Required(ErrorMessage="Email address is required")]
//      [BindProperty]
//      [EmailAddress]
//      public string Email { get; set; }

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

      // Navigation props
      public virtual IList<Gift> Gifts { get; set; }
      public virtual IList<Attendee> Attendees { get; set; }
   }
}
