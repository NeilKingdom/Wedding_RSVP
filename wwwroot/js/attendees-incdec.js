// JQuery functions for incrementing/decrementing form field using custom buttons

window.onbeforeunload = function() {
   sessionStorage.setItem("FirstName", $("#User_FirstName").val());
   sessionStorage.setItem("LastName", $("#User_LastName").val());
   sessionStorage.setItem("Email", $("#User_Email").val());
   sessionStorage.setItem("NumAttendees", $("#User_NumAttendees").val());
   sessionStorage.setItem("SongRequest", $("#User_SongRequest").val());
   sessionStorage.setItem("OtherInfo", $("#User_OtherInfo").val());

//   var attendees = [];
//   $("td[id^='Attendees_']").each(function(i, el) {
//      attendees.push(el.val());
//   });
//   sessionStorage.setItem("Attendees", attendees);
}

window.onload = function() {
   var firstName = sessionStorage.getItem("FirstName");
   var lastName = sessionStorage.getItem("LastName");
   var email = sessionStorage.getItem("Email");
   var numAttendees = sessionStorage.getItem("NumAttendees");
   var songRequest = sessionStorage.getItem("SongRequest");
   var otherInfo = sessionStorage.getItem("OtherInfo");
   var attendees = sessionStorage.getItem("Attendees");

   if (firstName !== null) $("#User_FirstName").val(firstName);
   if (lastName !== null) $("#User_LastName").val(lastName);
   if (email !== null) $("#User_Email").val(email);
   if (numAttendees !== null) $("#User_NumAttendees").val(numAttendees);
   if (songRequest !== null) $("#User_SongRequest").val(songRequest);
   if (otherInfo !== null) $("#User_OtherInfo").val(otherInfo);

//   attendees.each(function(i, el) {
//      if (el != null) {
//         $("#Attendees_" + i + "__FullName").val(el);
//      }
//   }
}

$(document).ready(function() {
	// Set the number of attendees field to 0 on document load
	$("#User_NumAttendees").val(0);

	// Event handler for increment button click
	$("#inc").click(function(e) {
		e.preventDefault(); // Prevent page reload
		// Increment number of attendees and display in text field
		var numAttendees = $("#User_NumAttendees").val();
		if (numAttendees < 5) {
			numAttendees++;
			// Add a new text field for attendee
			var index = parseInt($("#User_NumAttendees").val());
			index = (isNaN(index)) ? 1 : index + 1;

			var newField = '<tr id="attendee(' + index + ')">';
			newField		+= '<td>';
			newField    += '<span class="tf-header">Full Name for Attendee ' + index + '</span>';
			newField 	+= '<div><input type="text" placeholder="Full Name (Required)"'
            + 'id="Attendees_' 
            + (index-1) 
            + '__FullName" name="Attendees[' 
            + (index-1) 
            + '].FullName" /></div>';
			newField		+= '<span asp-validation-for="Attendees[' + (index-1) + '].FullName" class="text-danger"></span>';
			newField		+= '</td>';
			newField		+= '</tr>';
			$("#after-attendees").before(newField); // Insert before element with id #after-attendees
		}

		$("#User_NumAttendees").val(numAttendees);
	});

	// Event handler for decrement button click
	$("#dec").click(function(e) {
		e.preventDefault(); // Prevent page reload
		// Decrement number of attendees and display in text field
		var numAttendees = $("#User_NumAttendees").val();
		if (numAttendees > 0)
		{
			numAttendees--;
			// Remove the latest row (before back/continue buttons)
			$("#after-attendees").prev().remove();
		}

		$("#User_NumAttendees").val(numAttendees);
	});
});
