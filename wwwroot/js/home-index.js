var timeoutHandle;
var daysRemaining = 0;

$(document).ready(function() {
   // Clicks the first page link in the header to make it appear selected
   $(".hlink").first().click();
});

window.onload = setNumDaysRemaining();

/*
   Adds the slide button transition animation on hover, then
   reverses it after 5 seconds of the mouse exiting the carousel
*/
$("#my-carousel").hover(function() {
   window.clearTimeout(timeoutHandle);
   $(".slide-btn").addClass("slide-btn-transition");
}, function() { // Exit hover
   timeoutHandle = window.setTimeout(function() {
      $(".slide-btn").removeClass("slide-btn-transition");
   }, (5 * 1000))
});

// Gets the # of days until the wedding
function setNumDaysRemaining() {
   var wdToMsSinceEpoch = new Date(2023, (8 - 1), 26, (12 + 2 - 1)).getTime();
   daysRemaining = Math.round((wdToMsSinceEpoch - Date.now()) / (1000 * 60 * 60 * 24));
   if (daysRemaining < 0) daysRemaining = 0;
   $("#days-remaining").append(Math.trunc(daysRemaining).toString());
}
