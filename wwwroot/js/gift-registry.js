$(document).ready(function() {
   var numChecked = 0;
   var $giftContainers = $(".gift-container");
   var $tnEnlargeText = $(".enlarge-text");
   var $checkboxes = $("input[type=checkbox]");
   $checkboxes.prop("checked", false);

   // Gray out thumbnail image when mouse enters & undo on mouse exit
   $(".tn-container").hover(function() { // On mouse enter
      $(this).children(".enlarge-text").removeClass("enlarge-text-hidden");
      if (numChecked === 0) {
         $(this).children(".thumbnail").addClass("img-opaque");
      }
   }, function() { // On mouse leave
      $(this).children(".enlarge-text").addClass("enlarge-text-hidden");
      if (numChecked === 0) {
         $(this).children(".thumbnail").removeClass("img-opaque");
      }
   });

   // Resets all gift containers from looking disabled
   function clearDisabled() {
      $giftContainers.each(function() {
         $(this).removeClass("text-muted");
         $(this).find(".thumbnail").removeClass("img-opaque");
      });
   }

   // Alter CSS of gift containers and various other elements on checkbox click
   $checkboxes.click(function() {
      numChecked = 0;
      // Toggle rotation animation to make '+' become 'x' and vice versa
      $(this).siblings(".cbox").toggleClass("cbox-icon-plus", !this.checked);
      $(this).siblings(".cbox").toggleClass("cbox-icon-x", this.checked);

      $checkboxes.each(function() {
         if (this.checked) {
            numChecked++;
         }

         // Make all gift containers have muted text and opaque thumbnail aside from those that are selected
         $(this).closest(".gift-container").toggleClass("text-muted", !this.checked);
         $(this).closest(".gift-container").find(".thumbnail").toggleClass("img-opaque", !this.checked);
      });

      if (numChecked === 0) {
         clearDisabled();
      }
   });
});

function validateUserEmail() {
   if (localStorage.getItem("RegisteredEmail") === null) {
      alert("No email is registered");
   } else {
      alert("Email is " + localStorage.getItem("RegisteredEmail"));
   }
}
