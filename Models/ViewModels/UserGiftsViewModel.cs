namespace Wedding_RSVP.Models.ViewModels
{
   public class UserGiftViewModel
   {
      public User User { get; set; }
      public IEnumerable<Gift> Gifts { get; set; }
   }
}
