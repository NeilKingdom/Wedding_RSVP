using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Wedding_RSVP.Models
{
   public class Gift
   {
      [Column("GiftID")]
      public int ID { get; set; }

      [BindProperty]
      [Display(Name = "Example Image")]
      public string ImgUrl { get; set; }

      [BindProperty]
      public string SiteUrl { get; set; }

      [BindProperty]
      [DataType(DataType.Currency)]
      [Column(TypeName = "money")]
      [Display(Name = "Estimated Price")]
      public double EstPrice { get; set; }

      [BindProperty]
      [Display(Name = "Description")]
      [StringLength(50)]
      public string Desc { get; set; }

      public bool Available { get; set; }

      // Navigation props
      public virtual User User { get; set; }
   }
}
