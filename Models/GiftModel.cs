using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Wedding_RSVP.Models
{
   public class Gift
   {
      public int ID { get; set; }

      [StringLength(30)]
      public string Desc { get; set; }

      public bool Available { get; set; }
   }
}
