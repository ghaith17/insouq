$("button").on("click", function () {
    var input_text = $("input[type='text']");
    if (!input_text.val()) {
        input_text.css("border", "1px solid red");
    }
    var input_number = $("input[type='number']");
    if (!input_number.val()) {
        input_number.css("border", "1px solid red");
    }
    var select = $("select");
    if (!select.val()) {
        select.css("border", "1px solid red");
    }
    var textarea = $("textarea");
    if (!textarea.val()) {
        textarea.css("border", "1px solid red");
    }

});
$('input').on("change", function () {
    var input = $("input");
    if (input.val()) {
        input.css("border", "none");
    }
    var input_text = $("input[type='text']");
    if (!input_text.val()) {
        input_text.css("border", "none");
    }
    var input_number = $("input[type='number']");
    if (!input_number.val()) {
        input_number.css("border", "none");
    }
    var select = $("select");
    if (!select.val()) {
        select.css("border", "none");
    }
    var textarea = $("textarea");
    if (!textarea.val()) {
        textarea.css("border", "none");
    }
}); 