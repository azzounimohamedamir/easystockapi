//import { URL } from "url";

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $('#countryDropDownList').on("change", function () {
        var countryid = $('#countryDropDownList').val();
        var obj = { countryid: countryid };
        var url = URL.Content("~/") + "Cities/GetStates";
       
        AjaxCall("/admin/cities/GetStates", JSON.stringify(obj), 'POST').done(function (response) {
            if (response.length > 0) {
                $('#stateDropDownList').html('');
                
                var options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < response.length; i++) {
                    options += '<option value="' + response[i].Value + '">' + response[i].Text + '</option>';
                }
                $('#stateDropDownList').append(options);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

});

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}