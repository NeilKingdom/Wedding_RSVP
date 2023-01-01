$(document).ready(function() {
	// Activate Carousel
	$("#myCarousel").carousel("cycle");

	// Enable Carousel Controls
	$(".left").click(function() {
		$("#myCarousel").carousel("prev");
	});
	$(".right").click(function() {
		$("#myCarousel").carousel("next");
	});
});
