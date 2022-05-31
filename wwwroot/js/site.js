// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var routeURL = location.protocol + "//" + location.host;
function ajaxCheckFunction() {

    $.ajax({
        url: routeURL+"/home/AjaxCheck",
        type: 'GET',
        success: function (response) {
            console.log("response", response);
            $('#result').html(response);
        },
        error: function (xhr) {
            console.log("response", xhr);
        }
    });
}

function jsonCheckFunction() {

    $.ajax({
        headers:{
        url: routeURL + "/home/JsonCheck",
        type: 'GET',
        Accept: 'application/json'
    },
        success: function (response) {
            console.log("response", response);
            $('#result2').html(JSON.stringify(response));
        },
        error: function (xhr) {
            console.log("response", xhr);
        }
    });
}