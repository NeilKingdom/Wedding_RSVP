using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_RSVP.Models
{
   public class User
   {
      [Required]
      public string ID { get; set; }

      [Required]
      [StringLength(20, MinimumLength = 2)]
      public string FirstName { get; set; }

      [Required]
      [StringLength(20, MinimumLength = 2)]
      public string LastName { get; set; }

      [Required]
      [EmailAddress]
      public string Email { get; set; }

      [Required]
      [Range(1, 20)]
      public int Attendees { get; set; }
   }
}
