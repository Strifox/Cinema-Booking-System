$(document).ready();

var $loginPage = $("#loginToggle");
var $popupForm = $(".popup-form");

$loginToggle.on("click",
    function () {
        $popupForm.fadeToggle(300);
    });


