// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/js/site.js
$(function (){
    var PlaceholderElement = $('#Placeholder'); 
    $('button[data-toggle="modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url).done(function (data){
            PlaceholderElement.html(data);
            PlaceholderElement.find('.modal').modal('show');
        })
    })
})
=======
>>>>>>> 4bc58089133e7b82f8a462de98e46291788a0e8a:src/frontend/ServiceDeskUCAB/wwwroot/js/site.js
