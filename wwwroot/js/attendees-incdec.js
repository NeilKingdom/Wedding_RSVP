// JQuery functions for incrementing/decrementing form field using custom buttons

$("#inc").click(function() {
   var numAttendees = $("#NumAttendees").val();
   if (numAttendees < 15)
      numAttendees++;
   $("#NumAttendees").val(numAttendees);
});

$("#dec").click(function() {
   var numAttendees = $("#NumAttendees").val();
   if (numAttendees > 0)
      numAttendees--;
   $("#NumAttendees").val(numAttendees);
});
