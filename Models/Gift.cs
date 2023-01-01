using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_RSVP.Models
{
   public class Gift
   {
      [Column("GiftID")]
      public int ID { get; set; }

      // Foreign key reference
      public int GiftRef { get; set; }

      public string Url { get; set; }

      [StringLength(50)]
      public string Desc { get; set; }

      public bool Available { get; set; }

      // Navigation props
      public virtual User User { get; set; }
   }
}
