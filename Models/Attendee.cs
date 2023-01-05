using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_RSVP.Models
{
   public class Attendee
   {
      [Column("AttendeeID")]
      public int ID { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      [RegularExpression(@"[a-zA-Z]{2, 20} [a-zA-z]{2, 20}")]
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
