namespace Wedding_RSVP.Models.ViewModels
{
   public class UserGiftsViewModel
   {
      public User User { get; set; }
      public IEnumerable<Gift> Gifts { get; set; }
   }
}
