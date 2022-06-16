$("#subnav-one").on('click', function (e) {
	e.preventDefault();
	$("#project2").hide();
	$("#project1").show();
});

$("#subnav-two").on('click', function (e) {
	e.preventDefault();
	$("#project1").hide();
	$("#project2").show();
});