using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Wedding_RSVP.Models
{
   public class Gift
   {
      public int ID { get; set; }

      [StringLength(30)]
      public string Desc { get; set; }

      [DataType(DataType.Bool)]
      public bool Available { get; set; }
   }
}
