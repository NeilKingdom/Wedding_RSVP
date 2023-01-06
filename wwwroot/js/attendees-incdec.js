// JQuery functions for incrementing/decrementing form field using custom buttons

window.onbeforeunload = function() {
   localStorage.setItem("FirstName", $("#User_FirstName").val());
   localStorage.setItem("LastName", $("#User_LastName").val());
   localStorage.setItem("Email", $("#User_Email").val());
   localStorage.setItem("NumAttendees", $("#User_NumAttendees").val());

   $("td[id^='Attendees_']").each(function(i) {
      localStorage.setItem("Attendee" + i, $("Attendees_" + i + "__FullName").val());
   });
}

window.onload = function() {
   var firstName = localStorage.getItem("FirstName");
   var lastName = localStorage.getItem("LastName");
   var email = localStorage.getItem("Email");
   var numAttendees = localStorage.getItem("NumAttendees");
   var attendees = [];

   if (firstName !== null) $("#User_FirstName").val(firstName);
   if (lastName !== null) $("#User_LastName").val(lastName);
   if (email !== null) $("#User_Email").val(emal);
   if (numAttendees !== null) $("#User_NumAttendees").val(numAttendees);
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
			newField    += '<td>Full Name for Attendee ' + index + '</td>';
			newField		+= '<td>';
			newField 	+= '<input type="text" id="Attendees_' + (index-1) + '__FullName" name="Attendees[' + (index-1) + '].FullName" /><br />';
			newField		+= '<span asp-validation-for="Attendees[' + (index-1) + '].FullName" class="text-danger"></span>';
			newField		+= '</td>';
			newField		+= '</tr>';
			$(".table tr:last").before(newField); // Insert at end of table, but before back/continue buttons
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
			$(".table tr:last").prev().remove();
		}

		$("#User_NumAttendees").val(numAttendees);
	});
});

// Override form submit with AJAX call to avoid reloading the page when model does not bind
/*$("#submit").on("click", function(e) {
	e.preventDefault(); // Prevent normal form submit

   // Get all fields for ViewModel (seems like there should be a better way of doing this)
   var user = {
      FirstName: $("#User_FirstName").val(),
      LastName: $("#User_LastName").val(),
      Email: $("#User_Email").val(),
      NumAttendees: $("User_NumAttendees").val()
   }

   var attendees = [];
   $("td[id^='Attendees_']").each(function(i) { // For each <td> that begins with 'Attendees_'
      attendees.push({ FullName: $("Attendees_" + i + "__FullName").val() });
   });

   console.log(attendees);

   var viewModel = {
      "User": user,
      "Attendees": attendees
   }

   // Check if model state is valid on server-side
   var isValid = $.ajax({
      type: 'POST',
      url: '/User/UserAttendeesValidate',
      data: viewModel,
      datatype: 'json',
      success: function(data) {
         // If valid, run the action
         if (isValid) $.post('/User/RsvpForm', data);
      }
   });
});*/

