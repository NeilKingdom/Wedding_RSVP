// JQuery functions for incrementing/decrementing form field using custom buttons

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
/*$("#submit").on('"click", function(e) {
	e.preventDefault(); // Prevent normal form submit

	// Create form data object
	var formData = new FormData();

	// Check t
});*/

