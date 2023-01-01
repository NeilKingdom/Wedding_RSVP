using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_RSVP.Models
{
   public class User
   {
      [Column("UserID")]
      public int ID { get; set; }

      [Required]
      [DisplayName("First Name")]
      [StringLength(20, MinimumLength = 2)]
      public string FirstName { get; set; }

      [Required]
      [DisplayName("Last Name")]
      [StringLength(20, MinimumLength = 2)]
      public string LastName { get; set; }

      [Required]
      [EmailAddress]
      public string Email { get; set; }

      [Required]
      [Range(1, 20)]
      public int Attendees { get; set; }

      // Navigation props
      public virtual Gift Gift { get; set; }
   }
}
