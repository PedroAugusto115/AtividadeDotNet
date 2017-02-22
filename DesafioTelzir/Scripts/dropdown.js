function ajaxFailed(result) {
    alert("AJAX LOAD FAILED - Check your IIS Configuration: " + result.status + ' ' + result.statusText);
}

$(document).ready(function () {
    var serviceURLDropDown = 'Home/PopulateOriginDropDown';

    $.ajax({
        type: "POST",
        url: serviceURLDropDown,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $('#drpOrigem').append($('<option>').text('- Selecione -').attr('value', 0));
            $('#drpDestino').append($('<option>').text('- Selecione -').attr('value', 0));
            $.each(json, function (i, value) {
                $('#drpOrigem').append($('<option>').text(value).attr('value', value));
            });
        },
        error: ajaxFailed
    });
});

$.fillDestination = function () {
    var serviceURL = 'Home/PopulateDestinationDropDown';
    var postData = '{origin : "' + $('#drpOrigem').val() + '" }';

    $.ajax({
        type: "POST",
        url: serviceURL,
        data: postData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $('#drpDestino option').remove();
            $('#drpDestino').append($('<option>').text('- Selecione -').attr('value', 0));
            $.each(json, function (i, value) {
                $('#drpDestino').append($('<option>').text(value).attr('value', value));
            });
        },
        error: ajaxFailed
    });
};

function loadXMLDoc() {
    var serviceURL = 'Home/CalculateRateWithoutFaleMais';
    var serviceURL2 = 'Home/CalculatePriceWithFaleMais';

    var obj = {};
    obj.origin = $('#drpOrigem').val();
    obj.destination = $('#drpDestino').val();
    obj.minutes = $('#itminute').val();
    obj.falemais = $('input[name=rbfalemais]:checked').val();

    //var postData = '{origin : "' + $('#drpOrigem').val() + '", destination : "' + $('#drpDestination').val() + '" }';

    $.ajax({
        type: "POST",
        url: serviceURL,
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $('#sfalemais').val(json);
        },
        error: ajaxFailed
    }),

    $.ajax({
        type: "POST",
        url: serviceURL2,
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            $('#cfalemais').val(json);
        },
        error: ajaxFailed
    });
};
