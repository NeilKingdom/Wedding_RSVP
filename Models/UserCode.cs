using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Wedding_RSVP.Models
{
   public class UserCode
   {
      public int ID { get; set; }

      [Required(ErrorMessage="Code is required")]
      [BindProperty]
      [StringLength(9, MinimumLength=9, ErrorMessage="Invalid code")]
      public string Code { get; set; }

      // Navigation props
      public virtual User User { get; set; }
   }
}
