// JQuery functions for incrementing/decrementing form field using custom buttons

window.onbeforeunload = function() {
   sessionStorage.setItem("FirstName", $("#User_FirstName").val());
   sessionStorage.setItem("LastName", $("#User_LastName").val());
   sessionStorage.setItem("Email", $("#User_Email").val());
   sessionStorage.setItem("NumAttendees", $("#User_NumAttendees").val());
   sessionStorage.setItem("SongRequest", $("#User_SongRequest").val());
   sessionStorage.setItem("OtherInfo", $("#User_OtherInfo").val());

   // Create a JSON object containing each attendee and stringify it to be unwrapped later
   var attendees = {};
   $("input[id^='Attendees_']").each(function(i, el) {
      attendees[i] = $(el).val();
   });
   sessionStorage.setItem("Attendees", JSON.stringify(attendees));
}

/*window.onload = function() {
   var firstName = sessionStorage.getItem("FirstName");
   var lastName = sessionStorage.getItem("LastName");
   var email = sessionStorage.getItem("Email");
   var numAttendees = sessionStorage.getItem("NumAttendees");
   var songRequest = sessionStorage.getItem("SongRequest");
   var otherInfo = sessionStorage.getItem("OtherInfo");
   var attendees = JSON.parse(sessionStorage.getItem("Attendees"));

   if (firstName !== null) $("#User_FirstName").val(firstName);
   if (lastName !== null) $("#User_LastName").val(lastName);
   if (email !== null) $("#User_Email").val(email);
   if (numAttendees !== null) $("#User_NumAttendees").val(numAttendees);
   if (songRequest !== null) $("#User_SongRequest").val(songRequest);
   if (otherInfo !== null) $("#User_OtherInfo").val(otherInfo);

   // Invoke the increment onclick handler, then populate with the name stored in sessionStorage
   if (attendees !== null) {
      jQuery.each(attendees, function(i, el) {
         var index = parseInt(i);
			index = (isNaN(index)) ? 1 : index + 1;
			var newField = '<tr id="attendee(' + index + ')">';
			newField		+= '<td>';
			newField    += '<span class="tf-header">Full Name for Attendee ' + index + '</span>';
         newField    += '<div>';
         newField    += '<input id="Attendees_' + (index-1) + '__FullName" name="Attendees[' + (index-1) + '].FullName"'
                        + ' type="text" placeholder="Full Name (Required)" />';
         newField    += '</div>';
			newField		+= '</td>';
			newField		+= '</tr>';
			$("#after-attendees").before(newField);*/ // Insert before element with id #after-attendees
//         $("#Attendees_" + (index-1) + "__FullName").val(el);
//      });
//   }
//}

$(document).ready(function() {
	// Set the number of attendees field to 0 on document load
	$("#User_NumAttendees").val(0);

   $("#User_Email").keypress(function(event) {
      $(this).parent().next().remove();
   });

	// Event handler for increment button click
	$("#inc").click(function(event) {
		event.preventDefault(); // Prevent page reload

		var numAttendees = $("#User_NumAttendees").val();
		if (numAttendees < 5) {
			numAttendees++;
         
			// Add a new text field for attendee
			var index = parseInt($("#User_NumAttendees").val());
			index = (isNaN(index)) ? 1 : index + 1;

         // Add a row to the RSVP table
			var newField = '<tr id="attendee(' + index + ')">';
			newField		+= '<td>';
			newField    += '<span class="tf-header">Full Name for Guest ' + index + '</span>';
         newField    += '<div>';
         newField    += '<input id="Attendees_' + (index-1) + '__FullName" name="Attendees[' + (index-1) + '].FullName"'
                        + ' type="text" placeholder="Full Name (Required)" />';
         newField    += '</div>';
			newField		+= '</td>';
			newField		+= '</tr>';
			$("#after-attendees").before(newField); // Insert before element with id #after-attendees

         // Add attributes relating to input validation for the attendee fields
         var input = $('input[id="Attendees_' + (index-1) + '__FullName"]');
         $(input).attr("data-val", "true");
         $(input).attr("data-val-required", "Guest's full name is required");
         $(input).attr("data-val-regex-pattern", "^([a-zA-Z]{2,20})\\s+([a-zA-Z]{2,20})$");
         $(input).attr("data-val-regex", "Invalid format for full name");
         $(input).parent().after(
            '<span data-valmsg-for="Attendees[' + (index-1) + '].FullName"' +
            ' data-valmsg-replace="true" class="text-danger field-validation-error"></span>'
         );
		}

      // Update user count text field
		$("#User_NumAttendees").val(numAttendees);

      // Remove, then re-add the form's validator to have it recognize the newly added form fields
      $("form").removeData("validator").removeData("unobtrusiveValidation");
      $.validator.unobtrusive.parse($("form")); // Parse the form again
	});

	// Event handler for decrement button click
	$("#dec").click(function(event) {
		event.preventDefault(); // Prevent page reload

		var numAttendees = $("#User_NumAttendees").val();
		if (numAttendees > 0) {
			numAttendees--;
			// Remove the latest row (before back/continue buttons)
			$("#after-attendees").prev().remove();
		}

      // Update user count text field
		$("#User_NumAttendees").val(numAttendees);
	});

   // Load data stored in session storage
   var firstName = sessionStorage.getItem("FirstName");
   var lastName = sessionStorage.getItem("LastName");
   var email = sessionStorage.getItem("Email");
   var numAttendees = sessionStorage.getItem("NumAttendees");
   var songRequest = sessionStorage.getItem("SongRequest");
   var otherInfo = sessionStorage.getItem("OtherInfo");
   var attendees = JSON.parse(sessionStorage.getItem("Attendees"));

   if (firstName !== null) $("#User_FirstName").val(firstName);
   if (lastName !== null) $("#User_LastName").val(lastName);
   if (email !== null) $("#User_Email").val(email);
   if (numAttendees !== null) $("#User_NumAttendees").val(numAttendees);
   if (songRequest !== null) $("#User_SongRequest").val(songRequest);
   if (otherInfo !== null) $("#User_OtherInfo").val(otherInfo);

   // Invoke the increment onclick handler, then populate with the name stored in sessionStorage
   if (attendees !== null) {
	   $("#User_NumAttendees").val(0);
      jQuery.each(attendees, function(i, el) {
         var index = parseInt(i);
			index = (isNaN(index)) ? 1 : index + 1;
         $("#inc").click();
         $("#Attendees_" + (index-1) + "__FullName").val(el);
      });
   }
});
