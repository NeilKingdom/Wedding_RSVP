using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_RSVP.Models
{
   public class Attendee
   {
      [Column("AttendeeID")]
      public int ID { get; set; }

      [Required]
      [DisplayName("First Name")]
      [StringLength(20, MinimumLength = 2)]
      public string FirstName { get; set; }

      [Required]
      [DisplayName("Last Name")]
      [StringLength(20, MinimumLength = 2)]
      public string LastName { get; set; }

      // Navigation props
      public virtual User User { get; set; }
   }
}
