

$(document).ready(function(){

	$('#year-range-submit').hide();

	$("#min_year,#max_year").on('change', function () {

	  $('#year-range-submit').show();

	  var min_year_range = parseInt($("#min_year").val());

	  var max_year_range = parseInt($("#max_year").val());

	  if (min_year_range > max_year_range) {
		$('#max_year').val(min_year_range);
	  }

	  $("#slider-year-range").slider({
		values: [min_year_range, max_year_range]
	  });

	});


	$("#min_year,#max_year").on("paste keyup", function () {

	  $('#year-range-submit').show();

	  var min_year_range = parseInt($("#min_year").val());

	  var max_year_range = parseInt($("#max_year").val());

	  if(min_year_range == max_year_range){

			max_year_range = min_year_range + 1;

			$("#min_year").val(min_year_range);
			$("#max_year").val(max_year_range);
	  }

	  $("#slider-year-range").slider({
		values: [min_year_range, max_year_range]
	  });

	});


	$(function () {
	  $("#slider-year-range").slider({
		range: true,
		orientation: "horizontal",
		min: 1900,
		max: 2021,
		  values: [1900, 2021],
		step: 1,

		slide: function (event, ui) {
		  if (ui.values[0] == ui.values[1]) {
			  return false;
		  }

		  $("#min_year").val(ui.values[0]);
		  $("#max_year").val(ui.values[1]);
		}
	  });

	  $("#min_year").val($("#slider-year-range").slider("values", 0));
	  $("#max_year").val($("#slider-year-range").slider("values", 1));

	});

	$("#slider-year-range,#year-range-submit").click(function () {

	  var min_year = $('#min_year').val();
	  var max_year = $('#max_year').val();

	  $("#searchResults").text("Here List of products will be shown which are cost between " + min_year  +" "+ "and" + " "+ max_year + ".");
	});

});

$(document).ready(function () {

	$('#size-range-submit').hide();

	$("#min_size,#max_size").on('change', function () {

		$('#size-range-submit').show();

		var min_size_range = parseInt($("#min_size").val());

		var max_size_range = parseInt($("#max_size").val());

		if (min_size_range > max_size_range) {
			$('#max_size').val(min_size_range);
		}

		$("#slider-size-range").slider({
			values: [min_size_range, max_size_range]
		});

	});


	$("#min_size,#max_size").on("paste keyup", function () {

		$('#size-range-submit').show();

		var min_size_range = parseInt($("#min_size").val());

		var max_size_range = parseInt($("#max_size").val());

		if (min_size_range == max_size_range) {

			max_size_range = min_size_range + 1;

			$("#min_size").val(min_size_range);
			$("#max_size").val(max_size_range);
		}

		$("#slider-size-range").slider({
			values: [min_size_range, max_size_range]
		});

	});


	$(function () {
		$("#slider-size-range").slider({
			range: true,
			orientation: "horizontal",
			min: 0,
			max: 50000,
			values: [0, 50000],
			step: 1,

			slide: function (event, ui) {
				if (ui.values[0] == ui.values[1]) {
					return false;
				}

				$("#min_size").val(ui.values[0]);
				$("#max_size").val(ui.values[1]);
			}
		});

		$("#min_size").val($("#slider-size-range").slider("values", 0));
		$("#max_size").val($("#slider-size-range").slider("values", 1));

	});

	$("#slider-size-range,#size-range-submit").click(function () {

		var min_size = $('#min_size').val();
		var max_size = $('#max_size').val();

		$("#searchResults").text("Here List of products will be shown which are cost between " + min_size + " " + "and" + " " + max_size + ".");
	});

});


$(document).ready(function(){

	$('#km-range-submit').hide();

	$("#min_km,#max_km").on('change', function () {

	  $('#km-range-submit').show();

	  var min_km_range = parseInt($("#min_km").val());

	  var max_km_range = parseInt($("#max_km").val());

	  if (min_km_range > max_km_range) {
		$('#max_km').val(min_km_range);
	  }

	  $("#slider-km-range").slider({
		values: [min_km_range, max_km_range]
	  });

	});


	$("#min_km,#max_km").on("paste keyup", function () {

	  $('#km-range-submit').show();

	  var min_km_range = parseInt($("#min_km").val());

	  var max_km_range = parseInt($("#max_km").val());

	  if(min_km_range == max_km_range){

			max_km_range = min_km_range + 1000;

			$("#min_km").val(min_km_range);
			$("#max_km").val(max_km_range);
	  }

	  $("#slider-km-range").slider({
		values: [min_km_range, max_km_range]
	  });

	});


	$(function () {
	  $("#slider-km-range").slider({
		range: true,
		orientation: "horizontal",
		min: 0,
		max: 9000000,
		values: [0, 9000000],
		step: 1000,

		slide: function (event, ui) {
		  if (ui.values[0] == ui.values[1]) {
			  return false;
		  }

		  $("#min_km").val(ui.values[0]);
		  $("#max_km").val(ui.values[1]);
		}
	  });

	  $("#min_km").val($("#slider-km-range").slider("values", 0));
	  $("#max_km").val($("#slider-km-range").slider("values", 1));

	});

	$("#slider-km-range,#km-range-submit").click(function () {

	  var min_km = $('#min_km').val();
	  var max_km = $('#max_km').val();

	  $("#searchResults").text("Here List of products will be shown which are cost between " + min_km  +" "+ "and" + " "+ max_km + ".");
	});

});
