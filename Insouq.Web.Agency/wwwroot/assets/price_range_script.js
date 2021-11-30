$(document).ready(function(){

	$('#price-range-submit').hide();

	$("#min_price,#max_price").on('change', function () {

	  $('#price-range-submit').show();

	  var min_price_range = parseInt($("#min_price").val());

	  var max_price_range = parseInt($("#max_price").val());

	  if (min_price_range > max_price_range) {
		$('#max_price').val(min_price_range);
	  }

	  $("#slider-range").slider({
		values: [min_price_range, max_price_range]
	  });

	});

	$("#min_price,#max_price").on("paste keyup", function () {

	  $('#price-range-submit').show();

	  var min_price_range = parseInt($("#min_price").val());

	  var max_price_range = parseInt($("#max_price").val());

	  if(min_price_range == max_price_range){

			max_price_range = min_price_range + 100;

			$("#min_price").val(min_price_range);
			$("#max_price").val(max_price_range);
	  }

	  $("#slider-range").slider({
		values: [min_price_range, max_price_range]
	  });

	});


	$(function () {
	  $("#slider-range").slider({
		range: true,
		orientation: "horizontal",
		min: 0,
		max: 10000,
		values: [0, 10000],
		step: 100,

		slide: function (event, ui) {
		  if (ui.values[0] == ui.values[1]) {
			  return false;
		  }

		  $("#min_price").val(ui.values[0]);
		  $("#max_price").val(ui.values[1]);
		}
	  });

	  $("#min_price").val($("#slider-range").slider("values", 0));
	  $("#max_price").val($("#slider-range").slider("values", 1));

	});

	$("#slider-range,#price-range-submit").click(function () {

	  var min_price = $('#min_price').val();
	  var max_price = $('#max_price').val();

	  $("#searchResults").text("Here List of products will be shown which are cost between " + min_price  +" "+ "and" + " "+ max_price + ".");
	});

});


$(document).ready(function(){

	$('#year-range-submit').hide();

	$("#min_yeare,#max_year").on('change', function () {

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
		values: [min_price_range, max_price_range]
	  });

	});


	$(function () {
	  $("#slider-year-range").slider({
		range: true,
		orientation: "horizontal",
		min: 1990,
		max: 2021,
		values: [1990, 2021],
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
	  $("#max_price").val($("#slider-year-range").slider("values", 1));

	});

	$("#slider-year-range,#year-range-submit").click(function () {

	  var min_price = $('#min_year').val();
	  var max_price = $('#max_year').val();

	  $("#searchResults").text("Here List of products will be shown which are cost between " + min_year  +" "+ "and" + " "+ max_year + ".");
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
		values: [min_price_range, max_price_range]
	  });

	});


	$(function () {
	  $("#slider-km-range").slider({
		range: true,
		orientation: "horizontal",
		min: 0,
		max: 500000,
		values: [0, 500000],
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
	  $("#max_price").val($("#slider-km-range").slider("values", 1));

	});

	$("#slider-km-range,#km-range-submit").click(function () {

	  var min_price = $('#min_km').val();
	  var max_price = $('#max_km').val();

	  $("#searchResults").text("Here List of products will be shown which are cost between " + min_km  +" "+ "and" + " "+ max_km + ".");
	});

});
