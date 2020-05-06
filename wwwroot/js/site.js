// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".cell").click(function(elem) {
    var self = $(this).parent();
    self.toggleClass("selected");
})

printCard = function() {
    $('#printLink').hide();
    window.print();
    setTimeout(function() {
            $('#printLink').show();
        },
        500);
}