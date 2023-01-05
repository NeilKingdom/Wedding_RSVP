using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_RSVP.Models
{
   public class Gift
   {
      [Column("GiftID")]
      public int ID { get; set; }

      [Display(Name = "Example Image")]
      public string ImgUrl { get; set; }

      public string SiteUrl { get; set; }

      [DataType(DataType.Currency)]
      [Column(TypeName = "money")]
      [Display(Name = "Estimated Price")]
      public double EstPrice { get; set; }

      [Display(Name = "Description")]
      [StringLength(50)]
      public string Desc { get; set; }

      public bool Available { get; set; }

      // Navigation props
      public virtual User User { get; set; }
   }
}
